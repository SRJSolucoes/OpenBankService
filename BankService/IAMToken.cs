using Newtonsoft.Json;
using System;
using System.Net;
using System.IO;

namespace BankService
{
    public class Token

    {
        public class IAMToken
        {
            public string status { get; set; }
            public string jwt { get; set; }
        }

        public IAMToken GetQeshToken()
        {
            var wr = (HttpWebRequest)WebRequest.Create("https://api.qesh.ai/api/v1/user_token");
            wr.Proxy = null;
            wr.Method = "POST";
            wr.Accept = "application/json";
            wr.ContentType = "application/json";

            using (TextWriter tw = new StreamWriter(wr.GetRequestStream()))
            {
                tw.Write("{\"auth\": { \"email\": \"eduardo@srjsolucoes.com.br\", \"password\": \"Valentina3010\"}}");
            }

            var resp = wr.GetResponse();
            using (TextReader tr = new StreamReader(resp.GetResponseStream()))
            {
                var s = tr.ReadToEnd();
                return JsonConvert.DeserializeObject<IAMToken>(s);
            }
        }

        public IAMToken GetSupremCashToken()
        {
            var wr = (HttpWebRequest)WebRequest.Create("http://demoapi.suprem.cash/auth/login");
            wr.Proxy = null;
            wr.Method = "POST";
            wr.Accept = "application/json";
            wr.ContentType = "application/x-www-form-urlencoded";

            using (TextWriter tw = new StreamWriter(wr.GetRequestStream()))
            {
                tw.Write("user=sandbox:pass=123456:google_authenticator=");
            }
            var resp = wr.GetResponse();
            using (TextReader tr = new StreamReader(resp.GetResponseStream()))
            {
                var s = tr.ReadToEnd();
                return JsonConvert.DeserializeObject<IAMToken>(s);
            }
        }

    }
}

