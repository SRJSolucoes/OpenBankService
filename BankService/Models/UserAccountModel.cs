using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class UserAccountModel
    {
        public int id { get; set; }
        public int person_id { get; set; }
        public int account_id { get; set; }
        public string username { get; set; }
        public string fancy_name { get; set; }
        public string email { get; set; }
        public DateTime birth_date { get; set; }
        public string role { get; set; }
        public string occupation_area { get; set; }

        public int free_plan_limit { get; set; }
        public string document_type { get; set; }
        public string document { get; set; }
        public string phone { get; set; }
        public string single_charges { get; set; }
        public string active { get; set; }
        public string card_id { get; set; }
        public string virtual_card_id { get; set; }

        public string card_number { get; set; }
        public string photo { get; set; }
        public int accumulated_charges { get; set; }
        public string card_active { get; set; }
        public string virtual_card_active { get; set; }
        public string product_type { get; set; }
        public string user_type { get; set; }
        public string security { get; set; }


        public string first_access { get; set; }
        public string card_arrived { get; set; }
        public string contact_thumb { get; set; }
        public float free_monthly_billet { get; set; }
        public float ted_tax { get; set; }
        public float bill_tax { get; set; }

        public ISet<UserAliasAccountModel> alias { get; set; }
        public ISet<UserAccountDocument> userDocuments { get; set; }
        public ISet<UserAccountRegistration> registration { get; set; }

    }

}
