namespace AgendaMVC.Models
{
    public class Alerta
    {
        public int AlertaId { get; set; }

        public DateTime DataOcorrencia { get; set; }

        public int EventoId { get; set; }

        public Evento Evento { get; set; }
    }
}
