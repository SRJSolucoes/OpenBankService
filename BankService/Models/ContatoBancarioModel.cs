using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class ContatoBancarioModel
    {
        public int id { get; set; }
        public string nick_name { get; set; }
        public string name { get; set; }
        public string bank { get; set; }
        public string agency { get; set; }
        public string account { get; set; }
        public string email { get; set; }
        public string document { get; set; }
    }
}
