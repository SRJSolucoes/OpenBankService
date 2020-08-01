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
    public class APIQeshServices : IBankService
    {
        public AccountModel GetAccountDetail()
        {
            var iamtoken = new Token();
            var Tokem = iamtoken.GetQeshToken(Constantes.QeshUser, Constantes.QeshPass);

            String URL = String.Format("{0}(1)", Constantes.URLQesh, Constantes.ApiQeshAccountDetail);
            var client = new WebClient();

            client.Headers.Add(HttpRequestHeader.ContentType, "text/plain");
            client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + Tokem.jwt);

            using TextReader tr = new StreamReader(Encoding.UTF8.GetString(client.DownloadData(URL)));
            var s = tr.ReadToEnd();
            return JsonConvert.DeserializeObject<AccountModel>(s);
        }

        public TEDEnvioModel TED(TEDModel ted)
        {
            try
            {
                var iamtoken = new Token();
                var Tokem = iamtoken.GetQeshToken(Constantes.QeshUser, Constantes.QeshPass);
                String URL = String.Format("{0}(1)", Constantes.URLQesh, Constantes.ApiQeshTED);

                var wr = (HttpWebRequest)WebRequest.Create(URL);
                wr.Proxy = null;
                wr.Method = "POST";
                wr.Accept = "application/json";
                wr.ContentType = "application/json";
                
                wr.Headers.Add(HttpRequestHeader.ContentType, "text/plain");
                wr.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + Tokem.jwt);

                using (TextWriter tw = new StreamWriter(wr.GetRequestStream()))
                {

                    string str = JsonConvert.SerializeObject(ted);
                    tw.Write(str);
                }

                var resp = wr.GetResponse();

                using TextReader tr = new StreamReader(resp.GetResponseStream());
                var s = tr.ReadToEnd();
                return JsonConvert.DeserializeObject<TEDEnvioModel>(s);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
