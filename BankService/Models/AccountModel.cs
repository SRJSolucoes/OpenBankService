﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class AccountModel
    {
        public string status { get; set; }
        public ISet<UserAccountModel> UserAccountModel { get; set; }
    }
}
