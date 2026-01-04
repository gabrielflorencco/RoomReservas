using MediatR;
using RoomReservas.Application.DTOs.Usuarios;

namespace RoomReservas.Application.Queries.Usuarios.ListarUsuarios
{
    public record ListarUsuariosQuery : IRequest<List<ListarUsuariosResponse>>;
}
