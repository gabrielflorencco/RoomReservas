namespace RoomReservas.Domain.Exceptions
{
    public class CancelarReservaConfirmadaException : Exception
    {
        public CancelarReservaConfirmadaException() : base("Não é possível cancelar uma reserva que já foi confirmada.")
        {
        }
    }
}
