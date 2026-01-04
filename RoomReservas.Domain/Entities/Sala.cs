namespace RoomReservas.Domain.Entities
{
    public class Sala
    {
        public Guid Id { get; private set; } = new Guid();
        public string Nome { get; private set; }
        public int Capacidade { get; private set; }
        public bool Ativa { get; private set; }

        protected Sala() { }

        public Sala(string nome, int capacidade, bool ativa)
        {
            Nome = nome ?? throw new ArgumentNullException("Nome da sala não pode ser nulo");
            Capacidade = capacidade < 1 ? throw new ArgumentNullException("Capacidade da sala não pode ser menor que 1") : capacidade;
            Ativa = ativa;
        }

        public void Atualizar(string nome, int capacidade)
        {
            Nome = nome ?? throw new ArgumentNullException("Nome da sala não pode ser nulo");
            Capacidade = capacidade < 1 ? throw new ArgumentNullException("Capacidade da sala não pode ser menor que 1") : capacidade;
        }

        public void Desativar()
        {
            Ativa = false;
        }

        public void Ativar()
        {
            Ativa = true;
        }
    }
}
