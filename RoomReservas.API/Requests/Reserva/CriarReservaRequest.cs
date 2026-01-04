namespace RoomReservas.API.Requests.Reserva
{
    public class CriarReservaRequest
    {
        public Guid SalaId { get; set; }
        public Guid UsuarioId { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }
    }
}
