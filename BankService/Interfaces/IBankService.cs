using BankService.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Interfaces
{
    public interface IBankService 
    {
        void MakeDayTransfers(ILogger logger, IOperadora Operator, IBank banco);
        void LeituradeRetorno();
    }
}
