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
    }
}
