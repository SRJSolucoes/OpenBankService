using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService
{
    public static class Constantes
    {
        public const string URLQesh = "https://api.qesh.ai";
        public const string URLSRJ = "http://ec2-18-220-7-194.us-east-2.compute.amazonaws.com/LimaBtc";

        public const string ApiQeshAccountDetail = "/api/v1/account";
        public const string ApiSRJPagamentosdoDia = "/api/Pagamento/GetPagamentosDoDia";
        public const string ApiQeshTED = "/api/v1/account/to_bank_transfer";

        public const string QeshUser = "eduardo@srjsolucoes.com.br";
        public const string QeshPass = "Valentina3010";

        public const string SRJUser = "eduardo@srjsolucoes.com.br";
        public const string SRJPass = "Valentina3010";
    }
}
