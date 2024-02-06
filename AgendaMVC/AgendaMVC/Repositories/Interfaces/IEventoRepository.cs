using AgendaMVC.Models;

namespace AgendaMVC.Repositories.Interfaces
{
    public interface IEventoRepository
    {
        IEnumerable<Evento> GetEventos();
    }
}
