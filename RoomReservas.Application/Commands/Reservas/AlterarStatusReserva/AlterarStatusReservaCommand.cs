using MediatR;
using RoomReservas.Domain.Enums;

namespace RoomReservas.Application.Commands.Reservas.AlterarStatusReserva
{
    public record AlterarStatusReservaCommand(Guid idReserva, Status statusReserva) : IRequest<Unit>;
}
