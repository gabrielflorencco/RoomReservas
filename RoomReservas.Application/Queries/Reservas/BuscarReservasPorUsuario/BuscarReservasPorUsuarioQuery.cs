using MediatR;
using RoomReservas.Application.DTOs.Reservas;

namespace RoomReservas.Application.Queries.Reservas.BuscarReservaPorUsuario
{
    public record BuscarReservasPorUsuarioQuery(Guid usuarioId) : IRequest<List<BuscarReservaResponse>>;
}
