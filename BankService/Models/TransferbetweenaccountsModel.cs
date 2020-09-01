using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class TransferBetweenAccountsModel
    {
        public string transactionCode { get; set; }
        public int originalAccount { get; set; }
        public int destinationAccount { get; set; }
        public int amount { get; set; }
        public DateTime transactionDate { get; set; }
        public string description { get; set; }
        public int idAdjustment { get; set; }
        public int idIssuer { get; set; }
        public int idAdjustmentDestination { get; set; }
    }

}
