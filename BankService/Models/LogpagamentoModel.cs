using System;

namespace BankService.Models
{
    public class LogpagamentoModel
    {
        public int idlogpagamento { get; set; }

        public DateTime datalog { get; set; }

        public String status { get; set; }

        public String codretorno { get; set; }

        public String dsretorno { get; set; }

        public DateTime dataregistro { get; set; }

        public UsuarioIDModel usuario { get; set; }

        public PagamentoIDModel pagamento { get; set; }
    }
}
