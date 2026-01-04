using MediatR;
using RoomReservas.Application.DTOs.Usuarios;
using RoomReservas.Domain.RepositoriesInterfaces;

namespace RoomReservas.Application.Queries.Usuarios.BuscarUsuario
{
    public class BuscarUsuarioHandler(IUsuarioRepository usuarioRepository) : IRequestHandler<BuscarUsuarioQuery, BuscarUsuarioResponse>
    {
        public async Task<BuscarUsuarioResponse> Handle(BuscarUsuarioQuery request, CancellationToken cancellationToken)
        {
            var usuario = await usuarioRepository.BuscarPorIdAsync(request.Id);

            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado.");

            }
            return new BuscarUsuarioResponse
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            };
        }
    }
}
