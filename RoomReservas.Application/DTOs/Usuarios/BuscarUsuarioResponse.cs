namespace RoomReservas.Application.DTOs.Usuarios
{
    public class BuscarUsuarioResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
