namespace RoomReservas.Domain.Exceptions
{
    public class ReservaJaCanceladaException : Exception
    {
        public ReservaJaCanceladaException() : base("A reserva já está cancelada.")
        {
        }
    }
}
