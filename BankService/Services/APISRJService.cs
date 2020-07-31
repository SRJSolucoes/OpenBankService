using BankService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Services
{
    public class APISRJService
    {
        public List<PagamentoModel> GetLimaPagamentosdoDiaCorrente()
        {
            var iamtoken = new Token();
            var Tokem = iamtoken.GetSRJToken(Constantes.SRJUser, Constantes.SRJPass);

            String URL = String.Format("{0}{1}", Constantes.URLSRJ, Constantes.ApiSRJPagamentosdoDia);
            var client = new WebClient();

            client.Headers.Add(HttpRequestHeader.ContentType, "text/plain");
            client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + Tokem.jwt);

            var JSON = Encoding.UTF8.GetString(client.DownloadData(URL));
            return JsonConvert.DeserializeObject<List<PagamentoModel>>(JSON);
        }
    }
}
