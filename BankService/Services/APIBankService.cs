using BankService.Interfaces;
using BankService.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Services
{
    public class APIBankService : IBankService
    {
        public void MakeDayTransfers(ILogger logger, IOperadora operadora, IBank bank)
        {
            // pegando apenas 10 pagamentos sem filtro para os testes.
            foreach (PaymentModel payment in operadora.PaymentsoftheDay(bank.OriginBankCode))
            {
                try
                {
                    if (payment.cdbancodestino != payment.cdbancoorigem)
                    {
                        var destinyContact = bank.GetContacts(payment.documento, payment.cdbancodestino, payment.agenciadestino, payment.contadestino);
                        int contaId;
                        if (destinyContact == null)
                        {
                            ContactModel newContact = CreateContact(operadora, payment);

                            newContact = bank.IncludeContact(newContact);
                            contaId = (int)newContact.id;
                        }
                        else
                        {
                            contaId = destinyContact.id;
                        }

                        var tedStatus = bank.TED(operadora, payment, contaId);
                        //logger.LogInformation(tedStatus.message);

                    }
                    else
                    {
                        var qeshAccount = bank.GetContactQesh(payment.documento);
                        if (qeshAccount != null && qeshAccount.users.Count > 0)
                        {
                            var transferResult = bank.TransferBetweenAccounts(operadora, payment, qeshAccount.users[0].account_id);
                        }
                        else
                        {
                            operadora.LogPayment(
                                payment,
                                "Não foi possível encontrar a conta qesh com o documento informado"
                                );
                        }
                        //logger.LogInformation(transferResult.response.description);
                    }

                }
                catch (Exception ex)
                {
                    // Falta testar todo o fluxo
                    operadora.LogPayment(payment, ex.Message);
                }
            }
        }

        private static ContactModel CreateContact(IOperadora operadora, PaymentModel payment)
        {
            int bankId;
            Int32.TryParse(payment.cdbancodestino, out bankId);
            var numberAccount = payment.contadestino.Substring(0, payment.contadestino.Length - 1);
            var digitAccount = payment.contadestino.Substring(payment.contadestino.Length - 1);
            var extraContactInfo = operadora.GetContactInfo(payment);
            var firstName = extraContactInfo.nome.Split(" ")[0];

            var newContact = new ContactModel()
            {
                bank_id = bankId,
                agency_number = payment.agenciadestino,
                account_number = numberAccount,
                account_digit = digitAccount,
                name = extraContactInfo.nome,
                email = extraContactInfo.email,
                nick_name = firstName,
                document = payment.documento
            };
            return newContact;
        }

        public void LeituradeRetorno()
        {
            throw new NotImplementedException();
        }

        private String GetStatusPayment(TEDReturnModel tedSend)
        {
            return PaymentModel.getStatusPayment(tedSend.statusTransfer);
        }

    }

}
