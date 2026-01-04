using MediatR;

namespace RoomReservas.Application.Commands.Usuarios.CriarUsuario
{
    public record CriarUsuarioCommand : IRequest<Guid>
    {
        public string Nome { get; init; }
        public string Email { get; init; }
        public CriarUsuarioCommand(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }
}
