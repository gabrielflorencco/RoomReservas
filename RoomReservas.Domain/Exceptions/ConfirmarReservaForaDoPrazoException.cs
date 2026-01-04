namespace RoomReservas.Domain.Exceptions
{
    public class ConfirmarReservaForaDoPrazoException : Exception
    {
        public ConfirmarReservaForaDoPrazoException() : base("Não é possível confirmar uma reserva fora do prazo permitido.")
        {
        }
    }
}
