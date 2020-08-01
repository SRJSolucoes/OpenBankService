using BankService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Interfaces
{
    public interface IBankService 
    {
        AccountModel GetAccountDetail();
        TEDEnvioModel TED(TEDModel ted);
    }
}
