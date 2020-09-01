using BankService.Entities.SRJ.Framework.Core.Enum;
using BankService.Interfaces;
using BankService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace BankService.Services
{
    public class QeshServices : IBank
    {
        #region Constantes
        public const string URLQesh = "https://api.qesh.ai";
        public const string ApiQeshAccountDetail = "/api/v1/account";
        public const string ApiQeshContacts = "api/v1/users/contacts";
        public const string ApiContacts = "/api/v1/bank_account";
        public const string ApiQeshIncludeContacts = "/api/v1/bank_account/create";
        public const string ApiQeshTED = "/api/v1/account/to_bank_transfer";
        public const string ApiQeshTransferenciaEntreContas = "/api/v1/account/transfer_to_account";
        public const string ApiQeshTokem = "/api/v1/user_token";
        public const string QeshUser = "eduardo@srjsolucoes.com.br";
        public const string QeshPass = "Valentina3010";
        public const string QeshPass4Dig = "4506";

        #endregion

        #region QeshToken
        public class QeshToken
        {
            public string status { get; set; }
            public string jwt { get; set; }
        }
        public class QeshauthMaster
        {
            public QeshauthChield auth { get; set; }
        }
        public class QeshauthChield
        {
            public string email { get; set; }
            public string password { get; set; }
        }
        #endregion

        public string OriginBankCode { get => "655"; set => value = "655"; }

        public QeshToken GetQeshToken(string usuario, string senha)
        {
            String URL = String.Format("{0}{1}", URLQesh, ApiQeshTokem);
            var wr = (HttpWebRequest)WebRequest.Create(URL);
            wr.Proxy = null;
            wr.Method = "POST";
            wr.Accept = "application/json";
            wr.ContentType = "application/json";

            using (TextWriter tw = new StreamWriter(wr.GetRequestStream()))
            {
                QeshauthMaster Autenticador = new QeshauthMaster();
                Autenticador.auth = new QeshauthChield();
                Autenticador.auth.email = usuario;
                Autenticador.auth.password = senha;

                string str = JsonConvert.SerializeObject(Autenticador);
                tw.Write(str);
            }

            var resp = wr.GetResponse();

            using (TextReader tr = new StreamReader(resp.GetResponseStream()))
            {
                var s = tr.ReadToEnd();
                return JsonConvert.DeserializeObject<QeshToken>(s);
            }
        }
        public AccountModel GetAccountDetail()
        {
            var Tokem = GetQeshToken(QeshUser, QeshPass);

            String URL = String.Format("{0}{1}", URLQesh, ApiQeshAccountDetail);
            var client = new WebClient();

            client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + Tokem.jwt);

            using TextReader tr = new StreamReader(Encoding.UTF8.GetString(client.DownloadData(URL)));
            var s = tr.ReadToEnd();
            return JsonConvert.DeserializeObject<AccountModel>(s);
        }
        public ContactsModelSimple GetContacts(String document, String bank, String agency, String account)
        {
            try
            {
                var Token = GetQeshToken(QeshUser, QeshPass);
                String URL = String.Format("{0}{1}", URLQesh, ApiContacts);

                document = SanitizeValue(document);
                bank = SanitizeValue(bank);
                agency = SanitizeValue(agency);
                account = SanitizeValue(account);

                var wr = (HttpWebRequest)WebRequest.Create(URL);
                wr.Proxy = null;
                wr.Method = "GET";
                wr.Accept = "application/json";
                wr.ContentType = "application/json";

                wr.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + Token.jwt);

                var resp = wr.GetResponse();

                using TextReader tr = new StreamReader(resp.GetResponseStream());
                var s = tr.ReadToEnd();

                var contacts = JsonConvert.DeserializeObject<ContactsModelEnvelope>(s);

                var x = contacts.bank_accounts.FirstOrDefault(e =>
                    SanitizeValue(e.document) == document &&
                    SanitizeValue(e.agency) == agency &&
                    SanitizeValue(e.account) == account
                );

                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private String SanitizeValue(String data)
        {
            var newValue = data.Trim().Replace(".", "");
            newValue = newValue.Replace("-", "");

            return newValue;
        }
        public UserAccountEnvelope GetContactQesh(String Document)
        {
            try
            {
                var Tokem = GetQeshToken(QeshUser, QeshPass);
                Document = Document.Replace(".", "").Replace("-", "").Replace("/", "");
                var URLAPI = "https://api.qesh.ai/api/v1/users/accounts?document=";
                String URL = URLAPI + Document;

                var wr = (HttpWebRequest)WebRequest.Create(URL);
                wr.Proxy = null;
                wr.Method = "GET";
                wr.Accept = "application/json";
                wr.ContentType = "application/json";

                wr.Headers.Add(HttpRequestHeader.ContentType, "text/plain");
                wr.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + Tokem.jwt);

                var resp = wr.GetResponse();

                using TextReader tr = new StreamReader(resp.GetResponseStream());
                var s = tr.ReadToEnd();

                return JsonConvert.DeserializeObject<UserAccountEnvelope>(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public TEDMsgModel TED(IOperadora operadora, PaymentModel payment, int id_account)
        {
            var Tokem = GetQeshToken(QeshUser, QeshPass);
            String URL = String.Format("{0}{1}", URLQesh, ApiQeshTED);

            var wr = (HttpWebRequest)WebRequest.Create(URL);
            wr.Proxy = null;
            wr.Method = "POST";
            wr.Accept = "application/json";
            wr.ContentType = "application/json";

            wr.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + Tokem.jwt);

            using (TextWriter tw = new StreamWriter(wr.GetRequestStream()))
            {
                TEDModel ted = new TEDModel()
                {
                    id = id_account.ToString(),
                    value = payment.valor,
                    password = QeshPass4Dig
                };

                string str = JsonConvert.SerializeObject(ted);
                tw.Write(str);
            }

            var resp = wr.GetResponse();
            // Refactor too
            using (TextReader tr = new StreamReader(resp.GetResponseStream()))
            {
                var s = tr.ReadToEnd();
                var TEDResponse = JsonConvert.DeserializeObject<TEDMsgModel>(s);

                if (TEDResponse.status != 200 && TEDResponse.message != null)
                {
                    payment.status = StatusPayment.Rejeitado.GetValue().ToString();
                    operadora.LogPayment(payment, TEDResponse.message);
                }

                if (TEDResponse.status == 200 && TEDResponse.transfer != null && TEDResponse.message != null)
                {
                    payment.status = StatusPayment.EmProcessamento.GetValue().ToString();
                    payment.transactioncode = TEDResponse.transfer.transactionCode;
                    operadora.UpdatePayment(payment, TEDResponse.message);
                }

                return TEDResponse;
            }
        }

        public TransferBetweenAccountsEnvelope TransferBetweenAccounts(
            IOperadora operadora, PaymentModel payment, int id_account
        )
        {
            try
            {
                var Tokem = GetQeshToken(QeshUser, QeshPass);
                String URL = String.Format("{0}{1}", URLQesh, ApiQeshTransferenciaEntreContas);

                var wr = (HttpWebRequest)WebRequest.Create(URL);
                wr.Proxy = null;
                wr.Method = "POST";
                wr.Accept = "application/json";
                wr.ContentType = "application/json";

                //wr.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                wr.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + Tokem.jwt);

                TransferModel Transferbetweenaccounts = new TransferModel()
                {
                    account_id = id_account.ToString(),
                    value = payment.valor,
                    password = QeshPass4Dig
                };

                using (TextWriter tw = new StreamWriter(wr.GetRequestStream()))
                {

                    string str = JsonConvert.SerializeObject(Transferbetweenaccounts);
                    tw.Write(str);
                }

                var resp = wr.GetResponse();

                using TextReader tr = new StreamReader(resp.GetResponseStream());
                var s = tr.ReadToEnd();

                var TransferResponse = JsonConvert.DeserializeObject<TransferBetweenAccountsEnvelope>(s);
                if(TransferResponse.status != 200 && !String.IsNullOrWhiteSpace(TransferResponse.message))
                {
                    // falta identificar a assinatura da resposta quando for agendado a transferencia.
                    payment.status = StatusPayment.Rejeitado.GetValue().ToString();
                    operadora.UpdatePayment(payment, TransferResponse.message);
                }

                if (TransferResponse.status == 200 && TransferResponse.response != null)
                {
                    payment.status = StatusPayment.PagamentoRealizado.GetValue().ToString();
                    payment.transactioncode = TransferResponse.response.transactionCode;
                    payment.datapagamento = TransferResponse.response.transactionDate;
                    operadora.UpdatePayment(payment, TransferResponse.response.description);
                }

                return TransferResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ContactModel IncludeContact(ContactModel contact)
        {
            var Tokem = GetQeshToken(QeshUser, QeshPass);

            String URL = String.Format("{0}{1}", URLQesh, ApiQeshIncludeContacts);
            var wr = (HttpWebRequest)WebRequest.Create(URL);
            wr.Proxy = null;
            wr.Method = "POST";
            wr.Accept = "application/json";
            wr.ContentType = "application/json";

            wr.Headers.Add(HttpRequestHeader.ContentType, "text/plain");
            wr.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + Tokem.jwt);

            using (TextWriter tw = new StreamWriter(wr.GetRequestStream()))
            {
                string str = JsonConvert.SerializeObject(contact);
                tw.Write(str);
            }

            var resp = wr.GetResponse();

            using (TextReader tr = new StreamReader(resp.GetResponseStream()))
            {
                var respString = tr.ReadToEnd();

                var contactModel = JsonConvert.DeserializeObject<ContactModelEnvelope>(respString);

                return contactModel.bank_account;
            }
        }

        public ContactModel GetContact(string document, string bank, string agency, string account)
        {
            try
            {
                var Token = GetQeshToken(QeshUser, QeshPass);
                String URL = String.Format("{0}{1}", URLQesh, ApiContacts);

                var wr = (HttpWebRequest)WebRequest.Create(URL);
                wr.Proxy = null;
                wr.Method = "GET";
                wr.Accept = "application/json";
                wr.ContentType = "application/json";

                wr.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + Token.jwt);

                var resp = wr.GetResponse();

                using TextReader tr = new StreamReader(resp.GetResponseStream());
                var s = tr.ReadToEnd();

                var contact = JsonConvert.DeserializeObject<ContactModelEnvelope>(s);

                var x = contact.bank_account;

                return x;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
