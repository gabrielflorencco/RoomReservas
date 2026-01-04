using MediatR;
using RoomReservas.Application.DTOs.Reservas;
using RoomReservas.Domain.RepositoriesInterfaces;

namespace RoomReservas.Application.Queries.Reservas.BuscarReservasPorPeriodo
{
    public class BuscarReservasPorSalaEPeriodoHandler(IReservaRepository reservaRepository) : IRequestHandler<BuscarReservasPorSalaEPeriodoQuery, List<BuscarReservaResponse>>
    {
        public async Task<List<BuscarReservaResponse>> Handle(BuscarReservasPorSalaEPeriodoQuery request, CancellationToken cancellationToken)
        {
            var reservas = await reservaRepository.ObterReservasPorSalaEPeriodoAsync(request.idSala, request.dataInicio, request.dataFim);
            return reservas.Select(reserva => new BuscarReservaResponse
            {
                Id = reserva.Id,
                UsuarioId = reserva.UsuarioId,
                SalaId = reserva.SalaId,
                Inicio = reserva.Inicio,
                Fim = reserva.Fim,
                ValorTotal = reserva.ValorTotal,
                Status = reserva.Status,
                DataCriacao = reserva.DataCriacao
            }).ToList();
        }
    }
}
