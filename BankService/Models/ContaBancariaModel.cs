using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class ContaBancariaModel
    {
        public int idcontabancaria { get; set; }

        public String nome { get; set; }

        public String cdbanco { get; set; }

        public String tipoconta { get; set; }

        public String agencia { get; set; }

        public String conta { get; set; }

        public String vbinativa { get; set; }

        public String cdconvenio { get; set; }
    }
}
