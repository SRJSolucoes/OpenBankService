using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class TEDMsgModel
    {
        public string? message { get; set; }
        public int status { get; set; }
        public TEDSendModel? transfer { get; set; }
    }

}
