using AgendaMVC.Context;
using AgendaMVC.Models;
using AgendaMVC.Repositories.Interfaces;

namespace AgendaMVC.Repositories
{
    public class EventoRepository: IEventoRepository
    {
        private readonly AppDbContext _context;

        public EventoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Evento> GetEventos()
        {
            return _context.Eventos;
        }
    }
}
