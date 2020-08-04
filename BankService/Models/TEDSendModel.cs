using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class TEDSendModel
    {
        public string transactionCode { get; set; }
        public string originalAccount { get; set; }
        public string destinationAccount { get; set; }
        public float amount { get; set; }
        public DateTime transactionDate { get; set; }
        public string description { get; set; }
        public string idAdjustment { get; set; }
        public string idIssuer { get; set; }
        public string idAdjustmentDestination { get; set; }


        //Aqui teremos dois retornos diferentes, o primeiro oriundo de transferência internas e o segundo referentes a TED, verificar se precisa abrir em dois models
        /*
         #Transferência interna 
{
  "status": 200,
  "response": {
    "transactionCode": "617391873-4036-442810743 627720-832916-064497",
    "originalAccount": 984,
    "destinationAccount": 124,
    "amount": 0.01,
    "transactionDate": "2019-08-21T15:20:53.098",
    "description": "Qesh to Qesh Transfer",
    "idAdjustment": 7564,
    "idIssuer": 101,
    "idAdjustmentDestination": 7566
  }
}         
 
        #TED
        {
  "idOriginAccount": 10057584,
  "subIssuerCode": "103",
  "description": "Transferbank Description",
  "identificator": 123,
  "beneficiary": {
    "type": "fisico",
    "docIdCpfCnpjEinSSN": 47989793091,
    "name": "Jose da Silva Neves",
    "bankId": 237,
    "agency": 2309,
    "agencyDigit": "",
    "account": 121084,
    "accountDigit": "8",
    "accountType": "cc"
  },
  "value": 5.55,
  "idIssuer": 103,
  "UID": "103.cb1e1991-33b7-11e9-9111-02dec2710755",
  "date": "2019-02-18T17:00:12.585",
  "transactionCode": "769982744-9673-993539822 040370-459208-055886",
  "idAdjustment": 6229
}


          */









    }
}
