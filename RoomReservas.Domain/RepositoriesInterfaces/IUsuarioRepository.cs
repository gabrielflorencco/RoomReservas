using RoomReservas.Domain.Entities;

namespace RoomReservas.Domain.RepositoriesInterfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<bool> UsuarioAtingiuLimiteDeReserva(Guid usuarioId);
    }
}
