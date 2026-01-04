using MediatR;
using RoomReservas.Application.DTOs.Salas;

namespace RoomReservas.Application.Queries.Salas.BuscarSala
{
    public record BuscarSalaQuery(Guid Id) : IRequest<BuscarSalaResponse>;
}
