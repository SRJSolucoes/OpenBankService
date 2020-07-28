using System;
using System.Net;
using System.Text;

namespace BankService.Services
{
    public static class APIBankServices
    {
        public static void GetAccountDetail()
        {
            var iamtoken = new Token();
            var MyIAMTokem = iamtoken.GetQeshToken();

            String URL = "https://api.qesh.ai/api/v1/account";
            var client = new WebClient();

            client.Headers.Add(HttpRequestHeader.ContentType, "text/plain");
            client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + MyIAMTokem.jwt);

            var JSON = Encoding.UTF8.GetString(client.DownloadData(URL));
        }
    }
}
