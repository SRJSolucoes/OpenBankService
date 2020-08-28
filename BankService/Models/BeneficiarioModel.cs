using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class BeneficiarioModel
    {
        public int idbeneficiario { get; set; }

        public String nome { get; set; }

        public String cnpj { get; set; }

        public String cpf { get; set; }

        public String tplogradouro { get; set; }

        public String logradouro { get; set; }

        public String complemento { get; set; }

        public String numero { get; set; }

        public String bairro { get; set; }

        public String cidade { get; set; }

        public String uf { get; set; }

        public String cep { get; set; }

        public String pais { get; set; }

        public String email { get; set; }

        public String telefone { get; set; }
        public ISet<ContaBancariaModel> contabancarias { get; set; } = new HashSet<ContaBancariaModel>();
        public ISet<UsuarioIDModel> usuarios { get; set; } = new HashSet<UsuarioIDModel>();

    }
}
