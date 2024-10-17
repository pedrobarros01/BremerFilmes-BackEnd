namespace Dominio.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // A senha deve ser armazenada de forma segura (hash)
    }
}
