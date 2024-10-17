using Dominio.Model;

namespace Persistence.IRepository
{
    public interface IUserRepository
    {
        Task<User> Cadastrar(User userorg);
        User GetUserByUsername(string username);
    }
}
