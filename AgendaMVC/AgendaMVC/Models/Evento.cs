namespace AgendaMVC.Models
{
    public class Evento
    {
        public int EventoId { get; set; }

        public string Nome { get; set; }

        public DateTime DataInicialOcorrencia { get; set; }

        public DateTime DataFinalOcorrencia { get; set; }

        public bool Feito { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public List<Alerta> Alertas { get; set; }

        public int TipoEventoId { get; set; }

        public TipoEvento TipoEventos { get; set; }
    }
}
