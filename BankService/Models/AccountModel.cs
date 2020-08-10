﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class AccountModel
    {
        public int status { get; set; }
        public ISet<UserAccountModel> users { get; set; }
    }
}
