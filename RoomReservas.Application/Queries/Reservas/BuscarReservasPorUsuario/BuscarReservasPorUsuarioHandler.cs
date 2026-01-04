using MediatR;
using RoomReservas.Application.DTOs.Reservas;
using RoomReservas.Domain.RepositoriesInterfaces;

namespace RoomReservas.Application.Queries.Reservas.BuscarReservaPorUsuario
{
    public class BuscarReservasPorUsuarioHandler(IReservaRepository reservaRepository) : IRequestHandler<BuscarReservasPorUsuarioQuery, List<BuscarReservaResponse>>
    {
        public async Task<List<BuscarReservaResponse>> Handle(BuscarReservasPorUsuarioQuery request, CancellationToken cancellationToken)
        {
            var reservas = await reservaRepository.ObterReservasPorUsuarioAsync(request.usuarioId);
            return reservas.Select(reserva => new BuscarReservaResponse()
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
