using MediatR;

namespace RoomReservas.Application.Commands.Reservas.DeletarReserva
{
    public record DeletarReservaCommand(Guid idReserva) : IRequest<Unit>;
}
