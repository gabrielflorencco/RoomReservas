using MediatR;

namespace RoomReservas.Application.Commands.Salas.CriarSala
{
    public record CriarSalaCommand(string Nome, int Capacidade, bool Ativa) : IRequest<Guid>;
}
