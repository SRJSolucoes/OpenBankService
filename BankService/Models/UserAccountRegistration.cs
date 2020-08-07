using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class UserAccountRegistration
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string registration_id { get; set; }
        public string privacy_policy_token { get; set; }
        public string terms_of_use_token { get; set; }
        public string fingerprint { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
