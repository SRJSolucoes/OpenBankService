using BankService.Interfaces;
using BankService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Services
{
    public class APIBankService : IBankService
    {
        public void MakeDayTransfers(IOperadora operadora, IBank bank)
        {
            foreach (PaymentModel payment in operadora.PaymentsoftheDay(bank.OriginBankCode))
            {

                var TransferContact = bank.GetContact(payment.documento, payment.cdbancodestino, payment.agenciadestino, payment.contadestino); 
                if (TransferContact == null)
                {
                    TransferContact = bank.IncludeContact(new ContactsModel() { });
                }

                if (payment.cdbancodestino == payment.cdbancoorigem)
                    bank.Transferbetweenaccounts(new TransferbetweenaccountsModel());
                else
                    bank.TED(new TEDModel());

                payment.status = "E";
                payment.transactioncode = "XXXXXX";

                operadora.UpdatePayment(payment);
            }
        }

        public void LeituradeRetorno()
        {
            throw new NotImplementedException();
        }

    }
}
