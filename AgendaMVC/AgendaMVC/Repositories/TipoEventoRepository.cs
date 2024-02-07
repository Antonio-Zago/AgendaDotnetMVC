using AgendaMVC.Context;
using AgendaMVC.Models;
using AgendaMVC.Repositories.Interfaces;

namespace AgendaMVC.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly AppDbContext _appDbContext;

        public TipoEventoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public TipoEvento GetTipoEventoById(int id)
        {
            return _appDbContext.TipoEventos.Where(a => a.TipoEventoId == id).First();
        }

    }
}
