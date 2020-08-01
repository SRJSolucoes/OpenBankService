using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class TEDRetornoModel
    {

        public int id { get; set; }
        public string idAdjustment { get; set; }
        public string transactionCode { get; set; }
        public string idIssuer { get; set; }
        public string description { get; set; }
        public string idOriginAccount { get; set; }
        public float value { get; set; }
        public string typeAccountFavored { get; set; }
        public string nameFavored { get; set; }
        public string bankFavored { get; set; }
        public string agencyFavored { get; set; }
        public string digitAgencyFavored { get; set; }
        public string accountFavored { get; set; }
        public string digitAccountFavored { get; set; }
        public string cnabFileName { get; set; }
        public string statusTransfer { get; set; }
        public string tariffCode { get; set; }
        public string transferenceDate { get; set; }
        public string transferSuccess { get; set; }
        public string codStatusTransfer { get; set; }
        public string processDate { get; set; }
        public string uid { get; set; }
        public string cpfCnpjFavored { get; set; }


        /* Estrutura do retorno do webhook - pendente de modelagem
                "id": 323662,
        "idAdjustment": 102869,
        "transactionCode": "187330696-6396-979016860 797309-506904-771367",
        "idIssuer": 101,
        "description": "TED para ANDRE FRANCA DE AVILA",
        "idOriginAccount": 2681,
        "value": 366.16,
        "typeAccountFavored": "fisico",
        "nameFavored": "ANDRE FRANCA DE AVILA",
        "bankFavored": 341,
        "agencyFavored": 3832,
        "digitAgencyFavored": "",
        "accountFavored": 7363,
        "digitAccountFavored": "3",
        "cnabFileName": "WAITING_RETURN_FILE",
        "statusTransfer": "WAITING_PROCESSING",
        "tariffCode": "",
        "transferenceDate": "2020-07-24T12:30:19.699",
        "transferSuccess": null,
        "codStatusTransfer": "-1",
        "processDate": null,
        "uid": "101.946bd01e-cdc2-11ea-bcbb-0242ac110009",
        "cpfCnpjFavored": 79460089615 */
    }
}
