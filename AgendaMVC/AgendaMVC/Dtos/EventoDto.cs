namespace AgendaMVC.Dtos
{
    public class EventoDto
    {
        public string Nome { get; set; }

        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public bool Feito { get; set; }

        public string TipoEventoNome { get; set; }
    }
}
