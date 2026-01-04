using MediatR;

namespace RoomReservas.Application.Commands.Usuarios.AlterarUsuario
{
    public record AlterarUsuarioCommand(Guid Id, string Nome, string Email) : IRequest<Unit>;
}
