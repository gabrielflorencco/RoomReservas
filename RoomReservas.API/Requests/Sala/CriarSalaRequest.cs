namespace RoomReservas.API.Requests.Sala
{
    public class CriarSalaRequest
    {
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public bool Ativa { get; set; }
    }
}
