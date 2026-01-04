using MediatR;
using RoomReservas.Application.DTOs.Usuarios;

namespace RoomReservas.Application.Queries.Usuarios.BuscarUsuario
{
    public record BuscarUsuarioQuery(Guid Id) : IRequest<BuscarUsuarioResponse>;
}
