namespace RoomReservas.API.Requests.Sala
{
    public class AlterarSalaRequest
    {
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public bool Ativa { get; set; }
    }
}
