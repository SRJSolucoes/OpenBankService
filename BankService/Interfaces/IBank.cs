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
        ContactsModel IncludeContact(ContactsModel contact);
        ContactsModel GetContact(String Document, String Bank, String agency, String account);
        AccountModel GetContactQesh(String Document);
        TEDSendModel TED(int id_account, decimal value);
        TransferbetweenaccountsSendModel Transferbetweenaccounts(int id_account, decimal value);
    }
}
