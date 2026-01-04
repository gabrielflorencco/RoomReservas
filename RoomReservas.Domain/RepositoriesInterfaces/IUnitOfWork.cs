namespace RoomReservas.Domain.RepositoriesInterfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
