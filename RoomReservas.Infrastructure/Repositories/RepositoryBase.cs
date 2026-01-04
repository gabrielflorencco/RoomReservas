using Microsoft.EntityFrameworkCore;
using RoomReservas.Domain.RepositoriesInterfaces;
using RoomReservas.Infrastructure.Data;

namespace RoomReservas.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly RoomReservasDbContext _context;
        protected readonly IUnitOfWork _uow;

        public RepositoryBase(RoomReservasDbContext context, IUnitOfWork uow)
        {
            _dbSet = context.Set<T>();
            _context = context;
            _uow = uow;
        }

        public async Task<T> AdicionarAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _uow.CommitAsync();
            return entity;
        }

        public async Task<T> AlterarAsync(T entity)
        {
            _dbSet.Update(entity);
            await _uow.CommitAsync();
            return entity;
        }

        public async Task<T> BuscarPorIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task DeletarAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _uow.CommitAsync();
        }

        public async Task<bool> ExisteAsync(Guid id)
        {
            return await _dbSet.AnyAsync(e => EF.Property<Guid>(e, "Id") == id);
        }

        public async Task<List<T>> ListarTodosAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
