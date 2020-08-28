using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class UserAccountEnvelope
    {
        public int status { get; set; }
        public IList<UserAccountModel> users { get; set; }

    }

}
