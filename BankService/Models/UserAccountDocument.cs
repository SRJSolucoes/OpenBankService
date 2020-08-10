using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class UserAccountDocument
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public ISet<UrlDocAccountModel> document { get; set; }
        public string category { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
 }
