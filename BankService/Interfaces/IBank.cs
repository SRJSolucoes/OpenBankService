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
        List<ContactsModel> IncludeContact(ContactsModel contact);
        List<ContactsModel> GetContact(String Document, String Bank, String agency, String account);
        TEDSendModel TED(TEDModel ted);
        TransferbetweenaccountsSendModel Transferbetweenaccounts(TransferbetweenaccountsModel Transferbetweenaccounts);
    }
}
