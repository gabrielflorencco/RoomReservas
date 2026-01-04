using MediatR;
using RoomReservas.Application.DTOs.Reservas;

namespace RoomReservas.Application.Queries.Reservas.BuscarReservasPorSala
{
    public record BuscarReservasPorSalaQuery(Guid salaId) : IRequest<List<BuscarReservaResponse>>;
}
