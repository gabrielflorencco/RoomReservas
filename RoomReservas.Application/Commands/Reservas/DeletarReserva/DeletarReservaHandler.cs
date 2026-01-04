using MediatR;
using RoomReservas.Domain.RepositoriesInterfaces;

namespace RoomReservas.Application.Commands.Reservas.DeletarReserva
{
    public class DeletarReservaHandler(IReservaRepository reservaRepository) : IRequestHandler<DeletarReservaCommand, Unit>
    {
        public async Task<Unit> Handle(DeletarReservaCommand request, CancellationToken cancellationToken)
        {
            var reserva = await reservaRepository.BuscarPorIdAsync(request.idReserva);
            await reservaRepository.DeletarAsync(reserva);
            return Unit.Value;
        }
    }
}
