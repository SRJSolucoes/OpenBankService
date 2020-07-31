namespace BankService.Entities
{
    public class ResultadoProcessamento
    {
        public string Horario { get; set; }
        public string Status { get; set; }
        public object Exception { get; set; }
    }
}
