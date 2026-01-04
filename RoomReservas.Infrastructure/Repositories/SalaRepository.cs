using RoomReservas.Domain.Entities;
using RoomReservas.Domain.RepositoriesInterfaces;

namespace RoomReservas.Infrastructure.Repositories
{
    public class SalaRepository(IRepositoryBase<Sala> repository) : ISalaRepository
    {
        public async Task<Sala> AdicionarAsync(Sala entity)
        {
            await repository.AdicionarAsync(entity);
            return entity;
        }

        public async Task<Sala> AlterarAsync(Sala entity)
        {
            await repository.AlterarAsync(entity);
            return entity;
        }

        public async Task<bool> AtivarAsync(Guid id)
        {
            var sala = await repository.BuscarPorIdAsync(id);
            if (sala == null)
                return false;
            sala.Ativar();
            await repository.AlterarAsync(sala);
            return true;
        }

        public async Task<Sala> BuscarPorIdAsync(Guid id)
        {
            return await repository.BuscarPorIdAsync(id);
        }

        public async Task DeletarAsync(Sala entity)
        {
            await repository.DeletarAsync(entity);
        }

        public async Task<bool> DesativarAsync(Guid id)
        {
            var sala = await repository.BuscarPorIdAsync(id);
            if (sala == null)
                return false;
            sala.Desativar();
            await repository.AlterarAsync(sala);
            return true;
        }

        public async Task<bool> ExisteAsync(Guid id)
        {
            return await repository.ExisteAsync(id);
        }

        public async Task<List<Sala>> ListarTodosAsync()
        {
            return await repository.ListarTodosAsync();
        }
    }
}
