namespace RoomReservas.Domain.RepositoriesInterfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> BuscarPorIdAsync(Guid id);
        Task<List<T>> ListarTodosAsync();
        Task<T> AdicionarAsync(T entity);
        Task<T> AlterarAsync(T entity);
        Task DeletarAsync(T entity);
        Task<bool> ExisteAsync(Guid id);
    }
}
