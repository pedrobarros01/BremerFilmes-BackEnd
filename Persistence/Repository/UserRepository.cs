using Domain.Model;
using Domain.Structure;
using Dominio.Model;
using Persistence.Context;
using Persistence.IRepository;
using System.Linq;

namespace Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ResponseBase<User>> AtualizarUsuario(string descricao, string localizacao, int id)
        {
            try
            {
                ResponseBase<User> response = new ResponseBase<User>();
                User? user = _context.Users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    response.Status = false;
                    response.Mensagem = "Usuário não encontrado";
                    return response;
                }
                user.Descricao = descricao;
                user.Localizacao = localizacao;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                response.Dados = user;
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<User> Cadastrar(User userorg)
        {
            await _context.Users.AddAsync(userorg);
            await _context.SaveChangesAsync();
            return userorg;
        }

        public ResponseBase<User> GetUserById(int id)
        {
            User? user = _context.Users.FirstOrDefault(r => r.Id == id);
            ResponseBase<User> response = new ResponseBase<User>();
            if (user == null)
            {
                response.Status = false;
                response.Dados = null;
                response.Mensagem = "Não existe esse usuario";
                return response;
            }
            response.Status = true;
            response.Dados = user;
            return response;
        }

        public User? GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username); // Busca o usuário no banco de dados
        }
    }
}
