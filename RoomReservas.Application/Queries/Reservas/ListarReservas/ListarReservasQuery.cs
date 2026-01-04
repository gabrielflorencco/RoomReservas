using MediatR;
using RoomReservas.Application.DTOs.Reservas;

namespace RoomReservas.Application.Queries.Reservas.ListarReservas
{
    public record ListarReservasQuery : IRequest<List<ListarReservasResponse>>;
}
