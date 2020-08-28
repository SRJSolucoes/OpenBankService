using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class ContactsModelEnvelope
    {
        public int status { get; set; }
        public IList<ContactsModelSimple> bank_accounts { get; set; }
    }
}
