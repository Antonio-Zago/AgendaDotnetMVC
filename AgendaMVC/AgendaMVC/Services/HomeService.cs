using AgendaMVC.Dtos;
using AgendaMVC.Models;
using AgendaMVC.Repositories.Interfaces;
using System.Globalization;

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

            SetEventStatus(evento, dto);

            return dto;
        }

        private void SetEventStatus(Evento evento, EventoDto eventoDto)
        {
            var dataDeHoje = DateTime.Now;
            var diaSemanaHoje = dataDeHoje.DayOfWeek;
            var dataSemanaHoje = dataDeHoje.AddDays(7 - ((int)diaSemanaHoje));

            var dataMesHoje = dataDeHoje.AddMonths(1);

            var dataAnoHoje = dataDeHoje.AddYears(1);
            CultureInfo ptBR = new CultureInfo("pt-BR");


            if (evento.DataInicialOcorrencia.Date == dataDeHoje.Date || (!evento.DataFinalOcorrencia.Equals(null)  && evento.DataInicialOcorrencia.Date< dataDeHoje.Date && evento.DataFinalOcorrencia.Date >= dataDeHoje.Date))
            {
                eventoDto.StatusAtualEvento = "Hoje";
            }
            else if (evento.DataInicialOcorrencia.Date < dataDeHoje.Date && (evento.DataFinalOcorrencia.Equals(null) || evento.DataFinalOcorrencia.Date < dataDeHoje.Date ))
            {
                eventoDto.StatusAtualEvento = "Eventos passados";
            }
            else if (evento.DataInicialOcorrencia.Date < dataSemanaHoje.Date && evento.DataInicialOcorrencia.DayOfWeek > diaSemanaHoje)
            {
                eventoDto.StatusAtualEvento = "Essa semana";
            }
            else if (evento.DataInicialOcorrencia.Month == dataDeHoje.Month && evento.DataInicialOcorrencia < dataMesHoje)
            {
                eventoDto.StatusAtualEvento = "Esse Mês";
            }
            else if (evento.DataInicialOcorrencia.Year == dataDeHoje.Year && evento.DataInicialOcorrencia < dataAnoHoje)
            {
                eventoDto.StatusAtualEvento = ptBR.DateTimeFormat.GetMonthName(evento.DataInicialOcorrencia.Month);
            }
            else
            {
                eventoDto.StatusAtualEvento = "Eventos mais a frente";
            }
        }
    }
}
