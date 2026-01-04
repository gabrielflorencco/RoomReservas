using MediatR;

namespace RoomReservas.Application.Commands.Reservas.CriarReserva
{
    public record CriarReservaCommand(Guid usuarioId, Guid salaId, DateTime inicio, DateTime fim) : IRequest<Guid>;
}
