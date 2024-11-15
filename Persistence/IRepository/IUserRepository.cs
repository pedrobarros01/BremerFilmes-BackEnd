using Domain.Structure;
using Dominio.Model;

namespace Persistence.IRepository
{
    public interface IUserRepository
    {
        Task<User> Cadastrar(User userorg);
        User GetUserByUsername(string username);
        ResponseBase<User> GetUserById(int id);

        Task<ResponseBase<User>> AtualizarUsuario(string descricao, string localizacao, int id);
    }
}
