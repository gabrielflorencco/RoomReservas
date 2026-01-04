using RoomReservas.Domain.RepositoriesInterfaces;

namespace RoomReservas.Infrastructure.Data
{
    public class UnitOfWork(RoomReservasDbContext context) : IUnitOfWork
    {
        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
