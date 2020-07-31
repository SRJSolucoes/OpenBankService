using System;

namespace BankService.Models
{
    public class LotepagamentoSimpleModel
    {
        public int idlotepagamento { get; set; }
        public DateTime data { get; set; }
        public DateTime dataprevpagamento { get; set; }
        public String numremessa { get; set; }
    }
}
