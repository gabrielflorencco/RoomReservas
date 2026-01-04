using MediatR;
using RoomReservas.Application.DTOs.Salas;

namespace RoomReservas.Application.Queries.Salas.ListarSalas
{
    public record ListarSalasQuery : IRequest<List<ListarSalasResponse>>;
}
