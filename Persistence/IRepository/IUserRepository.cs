using Dominio.Model;

namespace Persistence.IRepository
{
    public interface IUserRepository
    {
        User GetUserByUsername(string username);
    }
}
