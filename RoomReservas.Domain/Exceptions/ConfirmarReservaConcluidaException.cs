namespace RoomReservas.Domain.Exceptions
{
    public class ConfirmarReservaConcluidaException : Exception
    {
        public ConfirmarReservaConcluidaException() : base("Não é possível confirmar uma reserva que já foi concluída.")
        {
        }
    }
}
