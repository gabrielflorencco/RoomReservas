using RoomReservas.Domain.Entities;

namespace RoomReservas.Domain.RepositoriesInterfaces
{
    public interface ISalaRepository : IRepositoryBase<Sala>
    {
        Task<bool> DesativarAsync(Guid id);
        Task<bool> AtivarAsync(Guid id);
    }
}
