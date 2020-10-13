using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class TEDSendModel
    {
        public string id { get; set; }
        public string transactionCode { get; set; }
        public int adjustment_id { get; set; }
        public int bank_account_id { get; set; }
        public string description { get; set; }
        public PaymentDocument receipt { get; set; }
        public string ted_tax { get; set; }
        public int transfer_id { get; set; }
        public decimal value { get; set; }
        public string user_id { get; set; }

    }

    public class PaymentDocument
    {
        public string url { get; set; }
    }
}
