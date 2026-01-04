using MediatR;
using RoomReservas.Application.DTOs.Usuarios;
using RoomReservas.Domain.RepositoriesInterfaces;

namespace RoomReservas.Application.Queries.Usuarios.ListarUsuarios
{
    public class ListarUsuariosHandler(IUsuarioRepository usuarioRepository) : IRequestHandler<ListarUsuariosQuery, List<ListarUsuariosResponse>>
    {
        public async Task<List<ListarUsuariosResponse>> Handle(ListarUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await usuarioRepository.ListarTodosAsync();
            return new List<ListarUsuariosResponse>(usuarios.Select(u => new ListarUsuariosResponse
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email
            }));
        }
    }
}
