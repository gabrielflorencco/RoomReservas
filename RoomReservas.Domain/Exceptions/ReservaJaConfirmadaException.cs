namespace RoomReservas.Domain.Exceptions
{
    public class ReservaJaConfirmadaException : Exception
    {
        public ReservaJaConfirmadaException() : base("A reserva já está confirmada.")
        {
        }
    }
}
