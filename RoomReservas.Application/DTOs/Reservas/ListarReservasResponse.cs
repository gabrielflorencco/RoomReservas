using RoomReservas.Domain.Enums;

namespace RoomReservas.Application.DTOs.Reservas
{
    public class ListarReservasResponse
    {
        public Guid Id { get; set; } = new Guid();
        public Guid UsuarioId { get; set; }
        public Guid SalaId { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public double ValorTotal { get; set; }
        public Status Status { get; set; } = Status.Pendente;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}
