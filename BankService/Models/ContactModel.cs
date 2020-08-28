using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class ContactModel
    {
        public int? id { get; set; }
        public string nick_name { get; set; }
        public string name { get; set; }
        public int? conductor_user_detail_id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public int? bank_account_id { get; set; }
        public string agency_number { get; set; }
        public string account_number { get; set; }
        public string account_digit { get; set; }
        public string document { get; set; }
        public string email { get; set; }
        public int bank_id { get; set; }

    }
}
