namespace RoomReservas.Domain.Exceptions
{
    public class CancelarReservaForaDoPrazoException : Exception
    {
        public CancelarReservaForaDoPrazoException() : base("Não é possível cancelar a reserva fora do prazo permitido.")
        {
        }
    }
}
