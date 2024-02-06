using AgendaMVC.Dtos;
using AgendaMVC.Models;
using AgendaMVC.Repositories.Interfaces;

namespace AgendaMVC.Services
{
    public class HomeService
    {
        private readonly IEventoRepository _eventoRepository;

        public HomeService(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public IEnumerable<EventoDto> GetEventos()
        {
            return _eventoRepository.GetEventos().Select(a => ConvertToEventoDto(a));
        }

        private EventoDto ConvertToEventoDto(Evento evento)
        {
            var dto = new EventoDto();
            dto.EventoId = evento.EventoId;

            return dto;
        }
    }
}
