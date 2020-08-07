using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class UserAliasAccountModel
    {
        public int ind { get; set; }
        public int conductor_user_detail_id { get; set; }
        public string bank_number { get; set; }
        public string bank_branch_number { get; set; }
        public string bank_account_number { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
