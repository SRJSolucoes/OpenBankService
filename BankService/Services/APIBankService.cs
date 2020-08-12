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
                if (payment.cdbancodestino != payment.cdbancoorigem)
                {
                    var TransferContact = bank.GetContact(payment.documento, payment.cdbancodestino, payment.agenciadestino, payment.contadestino);
                    if (TransferContact == null)
                    {
                        
                        TransferContact = bank.IncludeContact(new ContactsModel() { });
                    }

                    var bank_account = TransferContact.bank_accounts.First();

                    bank.TED(bank_account.id, payment.valor);
                }
                else
                {
                    var TransferContactQesh = bank.GetContactQesh(payment.documento);
                    //1. Recuperar ID da conta de destino
                    //bank.Transferbetweenaccounts('1',1);
                }
 
                payment.status = "E";
                payment.transactioncode = "XXXXXX";
                //operadora.UpdatePayment(payment);
            }
        }

        public void LeituradeRetorno()
        {
            throw new NotImplementedException();
        }

    }
}
