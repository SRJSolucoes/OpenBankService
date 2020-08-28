using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class ContactModelEnvelope
    {
        public int status { get; set; }
        public String message { get; set; }
        public ContactModel bank_account { get; set; }
    }
}
