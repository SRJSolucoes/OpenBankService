using BankService.Entities.SRJ.Framework.Core.Enum;
using BankService.Services;
using System;
using System.Collections.Generic;

namespace BankService.Models
{
    public class PaymentModel
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
        public String transactioncode { get; set; }
        public LotepagamentoSimpleModel lotepagamento { get; set; }
        public ISet<LogpagamentoModel> Logpagamento { get; set; }

        public static String getStatusPayment(String statusTransfer)
        {
            // Processing
            if (String.Compare(statusTransfer, "WAITING_PROCESSING", true) == 0)
            {
                return StatusPayment.EmProcessamento.GetValue().ToString();
            }

            // Success
            if (String.Compare(statusTransfer, "CREDIT_DONE", true) == 0
                || String.Compare(statusTransfer, "SUCCESS_INCLUSION_DONE", true) == 0)
            {
                return StatusPayment.PagamentoRealizado.GetValue().ToString();
            }

            // Falha
            if (
                String.Compare(statusTransfer, "REJECTED_REGISTER", true) == 0
                || String.Compare(statusTransfer, "FAILED_CREDIT_NOT_DONE", true) == 0
                || String.Compare(statusTransfer, "FAILED_INVALID_BENEFICIARY_ACCOUNT", true) == 0
                || String.Compare(statusTransfer, "FAILED_INVALID_BENEFICIARY_AGENCY", true) == 0
                || String.Compare(statusTransfer, "FAILED_INVALID_BENEFICIARY_SUBSCRIPTION_NUM_OR_TYPE", true) == 0
                )
            {
                return StatusPayment.Rejeitado.GetValue().ToString();
            }

            return StatusPayment.Agendado.GetValue().ToString();
        }
    }
}
