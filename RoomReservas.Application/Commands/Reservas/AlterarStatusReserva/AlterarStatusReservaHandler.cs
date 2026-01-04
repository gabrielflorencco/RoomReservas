using MediatR;
using RoomReservas.Domain.RepositoriesInterfaces;

namespace RoomReservas.Application.Commands.Reservas.AlterarStatusReserva
{
    public class AlterarStatusReservaHandler(IReservaRepository reservaRepository) : IRequestHandler<AlterarStatusReservaCommand, Unit>
    {
        public async Task<Unit> Handle(AlterarStatusReservaCommand request, CancellationToken cancellationToken)
        {
            var reserva = await reservaRepository.BuscarPorIdAsync(request.idReserva);

            if (request.statusReserva == Domain.Enums.Status.Confirmada)
            {
                await reservaRepository.ConfirmarReserva(reserva.Id);
            }
            else if (request.statusReserva == Domain.Enums.Status.Cancelada)
            {
                await reservaRepository.CancelarReserva(reserva.Id);
            }
            else if (request.statusReserva == Domain.Enums.Status.Concluida)
            {
                await reservaRepository.ConcluirReserva(reserva.Id);
            }
            else
            {
                throw new ArgumentException("Status de reserva inválido.");
            }

            return Unit.Value;
        }
    }
}
