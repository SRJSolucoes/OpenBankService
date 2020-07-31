using Newtonsoft.Json;
using System;
using System.Net;
using System.IO;

namespace BankService
{
    public class Token

    {
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

        #region SRJToken
        public class SRJToken
        {
            public string status { get; set; }
            public string jwt { get; set; }
        }
        #endregion

        public QeshToken GetQeshToken(string usuario, string senha)
        {
            var wr = (HttpWebRequest)WebRequest.Create("https://api.qesh.ai/api/v1/user_token");
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

        public SRJToken GetSRJToken(string usuario, string senha)
        {
            var wr = (HttpWebRequest)WebRequest.Create("http://ec2-18-220-7-194.us-east-2.compute.amazonaws.com/LimaBtc/oauth/login");
            wr.Proxy = null;
            wr.Method = "POST";
            wr.Accept = "application/json";
            wr.ContentType = "application/x-www-form-urlencoded";

            using (TextWriter tw = new StreamWriter(wr.GetRequestStream()))
            {
                tw.Write("username=" + usuario + ":password=" + senha + ":grant_type=password");
            }
            var resp = wr.GetResponse();
            using (TextReader tr = new StreamReader(resp.GetResponseStream()))
            {
                var s = tr.ReadToEnd();
                return JsonConvert.DeserializeObject<SRJToken>(s);
            }
        }
    }
}

