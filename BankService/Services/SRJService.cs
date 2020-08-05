using BankService.Interfaces;
using BankService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        public const string SRJUser = "eduardo@gmail.com";
        public const string SRJPass = "12345";

        public const string URLSRJ = "http://localhost:57334";
        //public const string SRJUser = "eduardo@srjsolucoes.com.br";
        //public const string SRJPass = "Valentina3010";

        public const string ApiSRJPagamentosdoDia = "/api/Pagamento/GetPagamentosDoDia";
        public const string ApiSRJAtualizaStatus = "api/pagamento/AlterStatus";
        public const string ApiSRJTokem = "/oauth/login";



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

        public List<PaymentModel>PaymentsoftheDay(String BancoOrigem)
        {
            var Tokem = GetSRJToken(SRJUser, SRJPass);

            String URL = String.Format("{0}{1}", URLSRJ, ApiSRJPagamentosdoDia);
            var client = new WebClient();

            client.Headers.Add(HttpRequestHeader.ContentType, "text/plain");
            client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + Tokem.access_token);

            var JSON = Encoding.UTF8.GetString(client.DownloadData(URL));
            return JsonConvert.DeserializeObject<List<PaymentModel>>(JSON).Where(x=> x.cdbancoorigem == BancoOrigem || x.transactioncode == null).ToList();
        }

        public void UpdatePayment(PaymentModel Payment)
        {
            throw new NotImplementedException();
        }
    }
}
