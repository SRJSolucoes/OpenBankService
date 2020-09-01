using BankService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Interfaces
{
    public interface IBank
    {
        public String OriginBankCode { get; set; }

        AccountModel GetAccountDetail();
        ContactModel IncludeContact(ContactModel contact);
        ContactModel GetContact(String Document, String Bank, String agency, String account);
        ContactsModelSimple GetContacts(String Document, String Bank, String agency, String account);
        UserAccountEnvelope GetContactQesh(String Document);
        TEDMsgModel TED(IOperadora operadora, PaymentModel payment, int id_account);
        TransferBetweenAccountsEnvelope TransferBetweenAccounts(IOperadora operadora, PaymentModel payment, int id_account);
    }
}
