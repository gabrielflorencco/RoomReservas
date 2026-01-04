using RoomReservas.Domain.Entities;
using RoomReservas.Domain.Enums;
using RoomReservas.Domain.RepositoriesInterfaces;
using RoomReservas.Infrastructure.Data;

namespace RoomReservas.Infrastructure.Repositories
{
    public class UsuarioRepository(IRepositoryBase<Usuario> repository, RoomReservasDbContext dbContext) : IUsuarioRepository
    {
        public async Task<Usuario> AdicionarAsync(Usuario entity)
        {
            await repository.AdicionarAsync(entity);
            return entity;
        }

        public async Task<Usuario> AlterarAsync(Usuario entity)
        {
            await repository.AlterarAsync(entity);
            return entity;
        }

        public async Task<Usuario> BuscarPorIdAsync(Guid id)
        {
            return await repository.BuscarPorIdAsync(id);
        }

        public async Task DeletarAsync(Usuario entity)
        {
            await repository.DeletarAsync(entity);
        }

        public async Task<bool> ExisteAsync(Guid id)
        {
            return await repository.ExisteAsync(id);
        }

        public async Task<List<Usuario>> ListarTodosAsync()
        {
            return await repository.ListarTodosAsync();
        }

        public Task<bool> UsuarioAtingiuLimiteDeReserva(Guid usuarioId)
        {
            var quantidadeReservasAtivas = dbContext.Reservas
                .Count(r => r.UsuarioId == usuarioId && (r.Status == Status.Confirmada || r.Status == Status.Pendente));

            if (quantidadeReservasAtivas >= 3)
            {
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
