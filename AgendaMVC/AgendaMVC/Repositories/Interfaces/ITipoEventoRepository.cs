using AgendaMVC.Models;

namespace AgendaMVC.Repositories.Interfaces
{
    public interface ITipoEventoRepository
    {
        TipoEvento GetTipoEventoById(int id);
    }
}
