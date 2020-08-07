using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class AccountDetModel
    {

        public int id { get; set; }
        public int idPessoa { get; set; }
        public string nome { get; set; }
        public int idProduto { get; set; }
        public int idOrigemComercial { get; set; }
        public string nomeOrigemComercial { get; set; }
        public int idFantasiaBasica { get; set; }
        public string nomeFantasiaBasica { get; set; }
        public int idStatusConta { get; set; }
        public string statusConta { get; set; }

        public DateTime diaVencimento { get; set; }
        public int melhorDiaCompra { get; set; }
        public DateTime dataStatusConta { get; set; }
        public DateTime dataCadastro { get; set; }
        public DateTime dataUltimaAlteracaoVencimento { get; set; }
        public DateTime dataHoraUltimaCompra { get; set; }
        public int numeroAgencia { get; set; }
        public int numeroContaCorrente { get; set; }
        public float valorRenda { get; set; }
        public string formaEnvioFatura { get; set; }
        public string titular { get; set; }
        public float limiteGlobal { get; set; }
        public float limiteSaqueGlobal { get; set; }
        public float saldoDisponivelGlobal { get; set; }
        public float saldoDisponivelSaque { get; set; }
        public string impedidoFinanciamento { get; set; }
        public int diasAtraso { get; set; }

        public DateTime proximoVencimentoPadrao { get; set; }
        public int idProposta { get; set; }
        public int quantidadePagamentos { get; set; }
        public int correspondencia { get; set; }

        public DateTime dataInicioAtraso { get; set; }
        public Double rotativoPagaJuros { get; set; }
        public Double totalPosProx { get; set; }
        public Double saldoAtualFinal { get; set; }
        public Double saldoExtratoAnterior { get; set; }
        public string aceitaNovaContaPorGrupoProduto { get; set; }
        public string funcaoAtiva { get; set; }
        public string possuiOverLimit { get; set; }


    }
}
