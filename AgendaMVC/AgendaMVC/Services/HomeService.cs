using AgendaMVC.Dtos;
using AgendaMVC.Models;
using AgendaMVC.Repositories.Interfaces;

namespace AgendaMVC.Services
{
    public class HomeService
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly ITipoEventoRepository _tipoEventoRepository;

        public HomeService(IEventoRepository eventoRepository, ITipoEventoRepository tipoEventoRepository)
        {
            _eventoRepository = eventoRepository;
            _tipoEventoRepository = tipoEventoRepository;   
        }

        public IEnumerable<EventoDto> GetEventos()
        {
            return _eventoRepository.GetEventos().Select(a => ConvertToEventoDto(a));
        }

        private EventoDto ConvertToEventoDto(Evento evento)
        {
            var dto = new EventoDto();
            dto.Nome = evento.Nome;
            dto.DataInicio = evento.DataInicialOcorrencia;
            dto.DataFim = evento.DataFinalOcorrencia;
            dto.Feito = evento.Feito;

            var tipoEvento = _tipoEventoRepository.GetTipoEventoById(evento.TipoEventoId);

            dto.TipoEventoNome = tipoEvento.Nome;

            return dto;
        }
    }
}
