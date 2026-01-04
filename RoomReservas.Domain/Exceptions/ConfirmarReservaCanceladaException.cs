namespace RoomReservas.Domain.Exceptions
{
    internal class ConfirmarReservaCanceladaException : Exception
    {
        public ConfirmarReservaCanceladaException() : base("Não é possível confirmar uma reserva que foi cancelada.")
        {
        }
    }
}
