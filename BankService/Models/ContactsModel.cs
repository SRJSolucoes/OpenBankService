﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class ContactsModel
    {
        public int status { get; set; }
        public ISet<ContactModelReturn> bank_accounts { get; set; }
    }
}
