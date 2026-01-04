using MediatR;
using RoomReservas.Domain.Entities;
using RoomReservas.Domain.RepositoriesInterfaces;

namespace RoomReservas.Application.Commands.Usuarios.CriarUsuario
{
    public class CriarUsuarioHandler(IUsuarioRepository usuarioRepository) : IRequestHandler<CriarUsuarioCommand, Guid>
    {
        public async Task<Guid> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario(request.Nome, request.Email);
            await usuarioRepository.AdicionarAsync(usuario);
            return usuario.Id;
        }
    }
}
