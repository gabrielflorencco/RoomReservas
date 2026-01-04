namespace RoomReservas.Domain.Exceptions
{
    public class ConcluirReservaAntesDoPrazoException : Exception
    {
        public ConcluirReservaAntesDoPrazoException() : base("Não é possível concluir a reserva antes do término do período reservado.")
        {
        }
    }
}
