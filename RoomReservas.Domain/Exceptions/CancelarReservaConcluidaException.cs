namespace RoomReservas.Domain.Exceptions
{
    public class CancelarReservaConcluidaException : Exception
    {
        public CancelarReservaConcluidaException() : base("Não é possível cancelar uma reserva que já foi concluída.")
        {
        }
    }
}
