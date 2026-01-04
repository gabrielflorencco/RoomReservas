namespace RoomReservas.Domain.Exceptions
{
    public class ReservaJaConcluidaException : Exception
    {
        public ReservaJaConcluidaException() : base("A reserva já está concluída.")
        {
        }
    }
}
