namespace RoomReservas.Domain.Exceptions
{
    public class ConcluirReservaCanceladaException : Exception
    {
        public ConcluirReservaCanceladaException() : base("Não é possível concluir uma reserva que foi cancelada.")
        {
        }
    }
}
