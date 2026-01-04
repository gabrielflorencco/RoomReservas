using RoomReservas.Domain.Enums;
using RoomReservas.Domain.Exceptions;

namespace RoomReservas.Domain.Entities
{
    public class Reserva
    {
        public Guid Id { get; private set; } = new Guid();
        public Guid UsuarioId { get; private set; }
        public Guid SalaId { get; private set; }
        public DateTime Inicio { get; private set; }
        public DateTime Fim { get; private set; }
        public double ValorTotal { get; private set; }
        public Status Status { get; private set; } = Status.Pendente;
        public DateTime DataCriacao { get; private set; } = DateTime.UtcNow;

        protected Reserva() { }

        public Reserva(Guid usuarioId, Guid salaId, DateTime inicio, DateTime fim)
        {
            UsuarioId = usuarioId;
            SalaId = salaId;

            ValidadarDatas(inicio, fim);

            Inicio = inicio;
            Fim = fim;
            ValorTotal = (fim - inicio).TotalHours * 39.99;
        }

        public void Confirmar(DateTime agora)
        {
            if (agora >= Fim)
            {
                throw new ConfirmarReservaForaDoPrazoException();
            }

            if (Status == Status.Concluida)
            {
                throw new ConfirmarReservaConcluidaException();
            }

            if (Status == Status.Cancelada)
            {
                throw new ConfirmarReservaCanceladaException();
            }

            if (Status == Status.Confirmada)
            {
                throw new ReservaJaConfirmadaException();
            }

            Status = Status.Confirmada;
        }

        public void Cancelar(DateTime agora)
        {
            if (agora >= Inicio)
            {
                throw new CancelarReservaForaDoPrazoException();
            }

            if (Status == Status.Confirmada)
            {
                throw new CancelarReservaConfirmadaException();
            }

            if (Status == Status.Concluida)
            {
                throw new CancelarReservaConcluidaException();
            }

            if (Status == Status.Cancelada)
            {
                throw new ReservaJaCanceladaException();
            }
            Status = Status.Cancelada;
        }

        public void Concluir(DateTime agora)
        {
            if (agora < Fim)
            {
                throw new ConcluirReservaAntesDoPrazoException();
            }
            if (Status == Status.Cancelada)
            {
                throw new ConcluirReservaCanceladaException();
            }
            if (Status == Status.Concluida)
            {
                throw new ReservaJaConcluidaException();
            }
            Status = Status.Concluida;
        }

        private static void ValidadarDatas(DateTime dataInicio, DateTime dataFim)
        {
            if (dataInicio >= dataFim)
            {
                throw new ArgumentException("A data de início deve ser anterior à data de fim.");
            }
        }
    }
}
