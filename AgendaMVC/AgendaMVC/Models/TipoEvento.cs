namespace AgendaMVC.Models
{
    public class TipoEvento
    {
        public int TipoEventoId { get; set; }

        public string Nome { get; set; }

        public string Cor { get; set; }

        public string Icone { get; set; }

        public List<Evento> Eventos { get; set; }

    }
}
