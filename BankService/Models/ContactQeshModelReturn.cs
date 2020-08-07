using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class ContactQeshModelReturn
    {
        public string name { get; set; }
        public string email { get; set; }
        public string document { get; set; }
        public int account_id { get; set; }
    }
}
