using MediatR;
using RoomReservas.Application.DTOs.Reservas;

namespace RoomReservas.Application.Queries.Reservas.BuscarReserva
{
    public record BuscarReservaQuery(Guid Id) : IRequest<BuscarReservaResponse>;
}
