using BankService.Interfaces;
using BankService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Services
{
    public class SRJService : IOperadora
    {
        #region Constantes
        //public const string URLSRJ = "http://ec2-18-220-186-213.us-east-2.compute.amazonaws.com/limabtc";
        //public const string SRJUser = "marciadosanjos14@gmail.com";
        //public const string SRJPass = "marciadosanjos123";

        public const string URLSRJ = "https://api.limadosanjos.com.br";

        public const string ApiSRJPagamentosdoDia = "/api/Pagamento/GetPagamentosDoDia";
        public const string ApiSRJAtualizaStatus = "/api/pagamento/alterarStatus";
        public const string ApiSRJTokem = "/oauth/login";
        public const string ApiSRJLogPagamento = "/api/Logpagamento";

        private string pSRJUser { get; set; }
        private string pSRJPass { get; set; }

        public SRJService(string psrjUser, string psrjPass)
        {
            pSRJUser = psrjUser;
            pSRJPass = psrjPass;
        }

        #endregion

        #region SRJToken
        public class SRJToken
        {
            public string access_token { get; set; }
            public string jwtoken_typet { get; set; }
            public Int32 expires_in { get; set; }
        }
        #endregion

        public SRJToken GetSRJToken(string usuario, string senha)
        {
            try
            {

                String URL = String.Format("{0}{1}", URLSRJ, ApiSRJTokem);
                var wr = (HttpWebRequest)WebRequest.Create(URL);
                wr.Proxy = null;
                wr.Method = "POST";
                wr.ContentType = "application/x-www-form-urlencoded";

                using (TextWriter tw = new StreamWriter(wr.GetRequestStream()))
                {
                    tw.Write("username=" + usuario + "&password=" + senha + "&grant_type=password");
                }

                var resp = wr.GetResponse();

                using (TextReader tr = new StreamReader(resp.GetResponseStream()))
                {
                    var s = tr.ReadToEnd();
                    return JsonConvert.DeserializeObject<SRJToken>(s);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PaymentModel> PaymentsoftheDay(String BancoOrigem)
        {
            try
            {
                var token = GetSRJToken(pSRJUser, pSRJPass);

                //String URL = String.Format("{0}{1}", URLSRJ, "/api/Pagamento/GetPagamentosEmAbertoLast");
                String URL = String.Format("{0}{1}", URLSRJ, ApiSRJPagamentosdoDia);
                var client = new WebClient();

                client.Headers.Add(HttpRequestHeader.ContentType, "text/plain");
                client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token.access_token);

                var resultData = Encoding.UTF8.GetString(client.DownloadData(URL));
                var payments = JsonConvert.DeserializeObject<List<PaymentModel>>(resultData)
                    .Where(x => x.cdbancoorigem == BancoOrigem || x.transactioncode == null);
                return payments.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LogPayment(PaymentModel Payment, string message)
        {
            try
            {
                var Tokem = GetSRJToken(pSRJUser, pSRJPass);
                String URL = String.Format("{0}{1}", URLSRJ, ApiSRJLogPagamento);

                var wr = (HttpWebRequest)WebRequest.Create(URL);
                wr.Proxy = null;
                wr.Method = "POST";
                wr.Accept = "application/json";
                wr.ContentType = "application/json";

                wr.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + Tokem.access_token);
                // TODO: Revisar
                using (TextWriter tw = new StreamWriter(wr.GetRequestStream()))
                {
                    LogpagamentoModel logpagamento = new LogpagamentoModel()
                    {
                        idlogpagamento = 0,
                        datalog = DateTime.UtcNow,
                        codretorno = "NULL",
                        status = Payment.status,
                        dsretorno = message,
                        dataregistro = DateTime.UtcNow,
                        transactioncode = Payment.transactioncode,
                        pagamento = new PaymentIDModel() { idpagamento = Payment.idpagamento },
                        usuario = new UsuarioIDModel() { idusuario = 0 }
                    };

                    string str = JsonConvert.SerializeObject(logpagamento);
                    tw.Write(str);
                }

                var resp = wr.GetResponse();

                using (TextReader tr = new StreamReader(resp.GetResponseStream()))
                {
                    var s = tr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdatePayment(PaymentModel payment, String descricao)
        {
            try
            {
                var token = GetSRJToken(pSRJUser, pSRJPass);
                //{{baseUrl}}/api/pagamento/AlterStatus?id=<integer>&status=<string>&DescricaoLog=<string>
                String URL = String.Format("{0}{1}/{2}",
                                URLSRJ, ApiSRJAtualizaStatus, payment.idpagamento);

                var wr = (HttpWebRequest)WebRequest.Create(URL);
                wr.Proxy = null;
                wr.Method = "PUT";
                wr.Accept = "application/json";
                wr.ContentType = "application/json";

                wr.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token.access_token);
                // TODO: Revisar
                using (TextWriter tw = new StreamWriter(wr.GetRequestStream()))
                {
                    string str = JsonConvert.SerializeObject(new
                    {
                        payment.idpagamento,
                        payment.status,
                        descricaoLog = descricao,
                        payment.transactioncode
                    });
                    tw.Write(str);
                }

                var resp = wr.GetResponse();

                using (TextReader tr = new StreamReader(resp.GetResponseStream()))
                {
                    var s = tr.ReadToEnd();
                }

                //var resultData = Encoding.UTF8.GetString(client.DownloadData(URL));
                ////var resultData = Encoding.UTF8.GetString(data);
                //var payment = JsonConvert.DeserializeObject<PaymentModel>(resultData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BeneficiarioModel GetContactInfo(PaymentModel payment)
        {
            try
            {
                var token = GetSRJToken(pSRJUser, pSRJPass);
                //{{baseUrl}}/api/pagamento/AlterStatus?id=<integer>&status=<string>&DescricaoLog=<string>
                String URL = String.Format("{0}{1}", URLSRJ, "/api/Beneficiario/ByFilter");

                var wr = (HttpWebRequest)WebRequest.Create(URL);
                wr.Proxy = null;
                wr.Method = "POST";
                wr.Accept = "application/json";
                wr.ContentType = "application/json";

                wr.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token.access_token);
                // TODO: Revisar
                using (TextWriter tw = new StreamWriter(wr.GetRequestStream()))
                {
                    if (payment.documento.Length <= 11)
                    {
                        var objeto = new { idBeneficiario = "", nomeBeneficiario = "", cnpjBeneficiario = "", cpfBeneficiario = payment.documento };
                        string str = JsonConvert.SerializeObject(objeto);
                        tw.Write(str);
                    }
                    else
                    {
                        var objeto = new { idBeneficiario = "", nomeBeneficiario = "", cnpjBeneficiario = payment.documento, cpfBeneficiario = "" };
                        string str = JsonConvert.SerializeObject(objeto);
                        tw.Write(str);
                    }

                }

                var resp = wr.GetResponse();

                using (TextReader tr = new StreamReader(resp.GetResponseStream()))
                {
                    var s = tr.ReadToEnd();
                    var list = JsonConvert.DeserializeObject<List<BeneficiarioModel>>(s);
                    var beneficiario = list.FirstOrDefault();
                    return beneficiario;
                }

                //var resultData = Encoding.UTF8.GetString(client.DownloadData(URL));
                ////var resultData = Encoding.UTF8.GetString(data);
                //var payment = JsonConvert.DeserializeObject<PaymentModel>(resultData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
