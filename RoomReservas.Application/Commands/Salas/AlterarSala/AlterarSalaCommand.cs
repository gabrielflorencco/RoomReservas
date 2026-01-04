using MediatR;

namespace RoomReservas.Application.Commands.Salas.AlterarSala
{
    public record AlterarSalaCommand(Guid Id, string Nome, int Capacidade, bool Ativa) : IRequest<Unit>;
}
