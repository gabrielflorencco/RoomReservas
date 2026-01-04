namespace RoomReservas.Application.DTOs.Salas
{
    public class BuscarSalaResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Capacidade { get; set; }
        public bool Ativa { get; set; }
    }
}
