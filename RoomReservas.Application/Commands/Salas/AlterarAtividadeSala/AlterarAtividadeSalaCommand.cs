using MediatR;

namespace RoomReservas.Application.Commands.Salas.AlterarAtividadeSala
{
    public record AlterarAtividadeSalaCommand(Guid Id) : IRequest<Unit>;
}
