using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankService.Models
{
    public class AccountModel
    {
        public int status { get; set; }
        public User user { get; set; }
        public int user_monthly_charges { get; set; }
        public int charges_number { get; set; }
        public float charges_value { get; set; }
        public object plan_contract { get; set; }
        public object installment_charges { get; set; }
        public Plan[] plans { get; set; }
        public Account account { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public object person_id { get; set; }
        public int account_id { get; set; }
        public string username { get; set; }
        public object fancy_name { get; set; }
        public string email { get; set; }
        public string birth_date { get; set; }
        public string role { get; set; }
        public object occupation_area { get; set; }
        public int free_plan_limit { get; set; }
        public string document_type { get; set; }
        public string document { get; set; }
        public string phone { get; set; }
        public int single_charges { get; set; }
        public bool active { get; set; }
        public object card_id { get; set; }
        public object virtual_card_id { get; set; }
        public object card_number { get; set; }
        public object photo { get; set; }
        public int accumulated_charges { get; set; }
        public bool card_active { get; set; }
        public object virtual_card_active { get; set; }
        public string product_type { get; set; }
        public string user_type { get; set; }
        public bool security { get; set; }
        public bool first_access { get; set; }
        public object card_arrived { get; set; }
        public object contact_thumb { get; set; }
        public int free_monthly_billet { get; set; }
        public string ted_tax { get; set; }
        public string bill_tax { get; set; }
        public object alias { get; set; }
        public string related_users { get; set; }
        public UserDocument[] documents { get; set; }
        public Registration registration { get; set; }
    }

    public class Registration
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string registration_id { get; set; }
        public string privacy_policy_token { get; set; }
        public string terms_of_use_token { get; set; }
        public string fingerprint { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class UserDocument
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public Document document { get; set; }
        public string category { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class Document
    {
        public string url { get; set; }
    }

    public class Account
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
        public object diaVencimento { get; set; }
        public object melhorDiaCompra { get; set; }
        public DateTime dataStatusConta { get; set; }
        public DateTime dataCadastro { get; set; }
        public object dataUltimaAlteracaoVencimento { get; set; }
        public object dataHoraUltimaCompra { get; set; }
        public int numeroAgencia { get; set; }
        public string numeroContaCorrente { get; set; }
        public float valorRenda { get; set; }
        public string formaEnvioFatura { get; set; }
        public bool titular { get; set; }
        public float limiteGlobal { get; set; }
        public float limiteSaqueGlobal { get; set; }
        public float saldoDisponivelGlobal { get; set; }
        public float saldoDisponivelSaque { get; set; }
        public bool impedidoFinanciamento { get; set; }
        public int diasAtraso { get; set; }
        public string proximoVencimentoPadrao { get; set; }
        public int idProposta { get; set; }
        public int quantidadePagamentos { get; set; }
        public int correspondencia { get; set; }
        public object dataInicioAtraso { get; set; }
        public float rotativoPagaJuros { get; set; }
        public float totalPosProx { get; set; }
        public float saldoAtualFinal { get; set; }
        public float saldoExtratoAnterior { get; set; }
        public object aceitaNovaContaPorGrupoProduto { get; set; }
        public object funcaoAtiva { get; set; }
        public bool possuiOverLimit { get; set; }
        public int behaviorScore { get; set; }
    }

    public class Plan
    {
        public int id { get; set; }
        public int charges_limit { get; set; }
        public string charge_unit_value { get; set; }
        public string charges_total_value { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
