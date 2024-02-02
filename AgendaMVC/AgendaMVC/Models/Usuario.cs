namespace AgendaMVC.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public bool EnvioEmail { get; set; }

        public bool EnvioTelefone { get; set; }


        public List<Evento> Eventos { get; set; }
    }
}
