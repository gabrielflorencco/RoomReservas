using Microsoft.EntityFrameworkCore;
using RoomReservas.Domain.Entities;
using RoomReservas.Domain.Enums;
using RoomReservas.Domain.RepositoriesInterfaces;
using RoomReservas.Infrastructure.Data;

namespace RoomReservas.Infrastructure.Repositories
{
    public class ReservaRepository(IRepositoryBase<Reserva> repository, RoomReservasDbContext dbContext) : IReservaRepository
    {
        public async Task<Reserva> AdicionarAsync(Reserva entity)
        {
            await repository.AdicionarAsync(entity);
            return entity;
        }

        public async Task<Reserva> AlterarAsync(Reserva entity)
        {
            await repository.AlterarAsync(entity);
            return entity;
        }

        public async Task<Reserva> BuscarPorIdAsync(Guid id)
        {
            return await repository.BuscarPorIdAsync(id);
        }

        public async Task<bool> CancelarReserva(Guid reservaId)
        {
            var reserva = await BuscarPorIdAsync(reservaId);
            if (reserva == null)
                return false;
            reserva.Cancelar(DateTime.Now);
            await AlterarAsync(reserva);
            return true;
        }

        public async Task<bool> ConcluirReserva(Guid reservaId)
        {
            var reserva = await BuscarPorIdAsync(reservaId);
            if (reserva == null)
                return false;
            reserva.Concluir(DateTime.Now);
            await AlterarAsync(reserva);
            return true;
        }

        public async Task<bool> ConfirmarReserva(Guid reservaId)
        {
            var reserva = await BuscarPorIdAsync(reservaId);
            if (reserva == null)
                return false;
            reserva.Confirmar(DateTime.Now);
            await AlterarAsync(reserva);
            return true;
        }

        public async Task DeletarAsync(Reserva entity)
        {
            await repository.DeletarAsync(entity);
        }

        public async Task<bool> ExisteAsync(Guid id)
        {
            return await repository.ExisteAsync(id);
        }

        public async Task<bool> ExisteConflitoDeHorarioAsync(Guid salaId, DateTime inicio, DateTime fim)
        {
            return await dbContext.Reservas.AnyAsync(r =>
                                        r.SalaId == salaId &&
                                        r.Status != Status.Cancelada &&
                                        inicio < r.Fim &&
                                        fim > r.Inicio
                                    );
        }

        public Task<List<Reserva>> ListarTodosAsync()
        {
            return repository.ListarTodosAsync();
        }

        public async Task<List<Reserva>> ObterReservasPorSalaAsync(Guid salaId)
        {
            return await dbContext.Reservas
                                    .Where(r => r.SalaId == salaId)
                                    .ToListAsync();
        }

        public async Task<List<Reserva>> ObterReservasPorSalaEPeriodoAsync(Guid salaId, DateTime inicio, DateTime fim)
        {
            return await dbContext.Reservas
                                    .Where(r => r.SalaId == salaId && r.Inicio >= inicio && r.Fim <= fim)
                                    .ToListAsync();
        }

        public async Task<List<Reserva>> ObterReservasPorUsuarioAsync(Guid usuarioId)
        {
            return await dbContext.Reservas
                                    .Where(r => r.UsuarioId == usuarioId)
                                    .ToListAsync();
        }
    }
}
