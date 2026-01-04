using MediatR;
using RoomReservas.Application.DTOs.Reservas;
using RoomReservas.Domain.RepositoriesInterfaces;

namespace RoomReservas.Application.Queries.Reservas.BuscarReserva
{
    public class BuscarReservaHandler(IReservaRepository reservaRepository) : IRequestHandler<BuscarReservaQuery, BuscarReservaResponse>
    {
        public async Task<BuscarReservaResponse> Handle(BuscarReservaQuery request, CancellationToken cancellationToken)
        {
            var reserva = await reservaRepository.BuscarPorIdAsync(request.Id);
            if (reserva == null)
                throw new KeyNotFoundException("Reserva não encontrada.");

            return new BuscarReservaResponse()
            {
                Id = reserva.Id,
                UsuarioId = reserva.UsuarioId,
                SalaId = reserva.SalaId,
                Inicio = reserva.Inicio,
                Fim = reserva.Fim,
                ValorTotal = reserva.ValorTotal,
                Status = reserva.Status,
                DataCriacao = reserva.DataCriacao
            };
        }
    }
}
