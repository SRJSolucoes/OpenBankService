using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class TransferModel
    {
        public string account_id { get; set; }
        public decimal value { get; set; }
        public string password { get; set; }
    }
}
