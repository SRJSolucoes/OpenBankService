using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class ContactQeshModel
    {
        public int status { get; set; }
        public ISet<ContactQeshModelReturn> ContactQeshModelReturn { get; set; }
     }
}
