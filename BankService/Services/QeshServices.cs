using BankService.Entities;
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

            client.Headers.Add(HttpRequestHeader.ContentType, "text/plain");
            client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + Tokem.jwt);

            using TextReader tr = new StreamReader(Encoding.UTF8.GetString(client.DownloadData(URL)));
            var s = tr.ReadToEnd();
            return JsonConvert.DeserializeObject<AccountModel>(s);
        }

        public ContactsModel GetContact(String Document, String Bank, String agency, String account)
        {
            try
            {
                var Tokem = GetQeshToken(QeshUser, QeshPass);
                String URL = String.Format("{0}{1}", URLQesh, ApiContacts);

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

                var contacts = JsonConvert.DeserializeObject<ContactsModel>(s);

                var x = contacts.bank_accounts.Where(e => e.document == Document &&
                                                         e.agency == agency &&
                                                         e.account == account
                                                   ).ToList();

                return contacts;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public AccountModel GetContactQesh(String Document)
        {
            try
            {

                var Tokem = GetQeshToken(QeshUser, QeshPass);
                String URL = "https://api.qesh.ai/api/v1/users/accounts?document="+Document.Replace(".", "").Replace("-", "").Replace("/", "");

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
                
                return JsonConvert.DeserializeObject<AccountModel>(s);
}
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public TEDSendModel TED(int id_account, decimal value)
        {
            try
            {
                var Tokem = GetQeshToken(QeshUser, QeshPass);
                String URL = String.Format("{0}{1}", URLQesh, ApiQeshTED);

                ServicePointManager.ServerCertificateValidationCallback = delegate { return false; }; 
                
                var wr = (HttpWebRequest)WebRequest.Create(URL);
                wr.Proxy = null;
                wr.Method = "POST";
                wr.Accept = "*/*";
                wr.ContentType = "application/json";

                TEDModel ted = new TEDModel()
                {
                    id = id_account.ToString(),
                    value = value,
                    password = QeshPass4Dig
                };

                ASCIIEncoding encoding = new ASCIIEncoding();
                
                var tedbytes = encoding.GetBytes(ted.ToString());

                wr.ContentLength = tedbytes.Length;
                wr.Host = "www.qesh.ai";

                wr.Headers.Add(HttpRequestHeader.ContentType, "text/plain");
                wr.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + Tokem.jwt);

                using (TextWriter tw = new StreamWriter(wr.GetRequestStream()))
                {

                    string str = JsonConvert.SerializeObject(ted);
                    tw.Write(str);
                }
                //[TA DANDO ERRO AQUI.]
                var resp = wr.GetResponse();

                using TextReader tr = new StreamReader(resp.GetResponseStream());
                var s = tr.ReadToEnd();
                return JsonConvert.DeserializeObject<TEDSendModel>(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TransferbetweenaccountsSendModel Transferbetweenaccounts(int id_account, decimal value)
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

                wr.Headers.Add(HttpRequestHeader.ContentType, "text/plain");
                wr.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + Tokem.jwt);

                TEDModel Transferbetweenaccounts = new TEDModel()
                {
                    id = id_account.ToString(),
                    value = value,
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
                return JsonConvert.DeserializeObject<TransferbetweenaccountsSendModel>(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ContactsModel IncludeContact(ContactsModel contact)
        {
            var Tokem = GetQeshToken(QeshUser, QeshPass);

            String URL = String.Format("{0}{1}", URLQesh, ApiQeshIncludeContacts);
            var client = new WebClient();

            client.Headers.Add(HttpRequestHeader.ContentType, "text/plain");
            client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + Tokem.jwt);

            using TextReader tr = new StreamReader(Encoding.UTF8.GetString(client.DownloadData(URL)));
            var s = tr.ReadToEnd();
            return JsonConvert.DeserializeObject<ContactsModel>(s);

        }
    }
}
