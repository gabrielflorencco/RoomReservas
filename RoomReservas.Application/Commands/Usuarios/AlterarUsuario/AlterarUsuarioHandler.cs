using MediatR;
using RoomReservas.Domain.RepositoriesInterfaces;

namespace RoomReservas.Application.Commands.Usuarios.AlterarUsuario
{
    public class AlterarUsuarioHandler(IUsuarioRepository usuarioRepository) : IRequestHandler<AlterarUsuarioCommand, Unit>
    {
        public async Task<Unit> Handle(AlterarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await usuarioRepository.BuscarPorIdAsync(request.Id);
            if (usuario == null)
            {
                throw new KeyNotFoundException("Usuário não encontrado.");
            }

            usuario.Atualizar(request.Nome, request.Email);
            await usuarioRepository.AlterarAsync(usuario);
            return await Task.FromResult(Unit.Value);
        }
    }
}
