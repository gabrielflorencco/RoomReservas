namespace RoomReservas.Application.DTOs.Usuarios
{
    public class ListarUsuariosResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
