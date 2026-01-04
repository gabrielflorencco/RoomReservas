using System.Text.RegularExpressions;

namespace RoomReservas.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; } = new Guid();
        public string Nome { get; private set; }
        public string Email { get; private set; }

        protected Usuario() { }

        public Usuario(string nome, string email)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            ValidarEmail(email);
            ValidarNome(nome);
        }

        public void Atualizar(string nome, string email)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            ValidarEmail(email);
            ValidarNome(nome);
        }

        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome) || nome.Length < 2)
                throw new ArgumentException("Nome deve ter pelo menos 2 caracteres.");
        }

        private static void ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email inválido.", nameof(email));

            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            if (!regex.IsMatch(email))
                throw new ArgumentException("Email inválido.", nameof(email));
        }
    }
}
