using BankService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Interfaces
{
    public interface IOperadora
    {
        public List<PaymentModel> PaymentsoftheDay(String BancoOrigem);
        public void UpdatePayment(PaymentModel Payment);
        public void LogPayment(PaymentModel Payment, string message);
    }
}
