using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class TransferBetweenAccountsEnvelope
    {
        public int status { get; set; }
        public string? message { get; set; }
        public TransferBetweenAccountsModel? response { get; set; }
    }
}
