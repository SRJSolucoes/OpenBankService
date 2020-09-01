using BankService.Entities;

namespace BankService.Models
{
    public enum StatusPayment
    {
        [EnumValue("A")]
        Agendado,

        [EnumValue("R")]
        Rejeitado,

        [EnumValue("E")]
        EmProcessamento,

        [EnumValue("P")]
        PagamentoRealizado
    }
}
