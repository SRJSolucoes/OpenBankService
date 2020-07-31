using System;
using System.Collections.Generic;

namespace BankService.Models
{
    public class PagamentoModel
    {
        public int idpagamento { get; set; }
        public DateTime dataprevpagamento { get; set; }
        public DateTime datapagamento { get; set; }
        public DateTime dtcadastro { get; set; }
        public String cnpjempresa { get; set; }
        public String razaosocial { get; set; }
        public String enderecoempresa { get; set; }
        public String numenderecoempresa { get; set; }
        public String complendempresa { get; set; }
        public String bairroempresa { get; set; }
        public String cidadeempresa { get; set; }
        public String ufempresa { get; set; }
        public String cdbancoorigem { get; set; }
        public String tipocontaorigem { get; set; }
        public String agenciaorigem { get; set; }
        public String contaorigem { get; set; }
        public String tppessoa { get; set; }
        public String documento { get; set; }
        public String cdbancodestino { get; set; }
        public String tipocontadestino { get; set; }
        public String agenciadestino { get; set; }
        public String contadestino { get; set; }
        public decimal valor { get; set; }
        public String status { get; set; }
        public String cdconvenio { get; set; }
        public String nomefavorecido { get; set; }
        public String enderecofavorecido { get; set; }
        public String numenderecofavorecido { get; set; }
        public String complendfavorecido { get; set; }
        public String bairrofavorecido { get; set; }
        public String cidadefavorecido { get; set; }
        public String uffavorecido { get; set; }
        public String tipopagamento { get; set; }
        public LotepagamentoSimpleModel lotepagamento { get; set; }
        public ISet<LogpagamentoModel> Logpagamento { get; set; }
    }
}
