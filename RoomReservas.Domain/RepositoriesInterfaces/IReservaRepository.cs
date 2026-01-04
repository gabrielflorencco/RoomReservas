using RoomReservas.Domain.Entities;

namespace RoomReservas.Domain.RepositoriesInterfaces
{
    public interface IReservaRepository : IRepositoryBase<Reserva>
    {
        Task<bool> ExisteConflitoDeHorarioAsync(Guid salaId, DateTime inicio, DateTime fim);
        Task<List<Reserva>> ObterReservasPorSalaEPeriodoAsync(Guid salaId, DateTime inicio, DateTime fim);
        Task<List<Reserva>> ObterReservasPorUsuarioAsync(Guid usuarioId);
        Task<List<Reserva>> ObterReservasPorSalaAsync(Guid salaId);
        Task<bool> ConfirmarReserva(Guid reservaId);
        Task<bool> ConcluirReserva(Guid reservaId);
        Task<bool> CancelarReserva(Guid reservaId);
    }
}
