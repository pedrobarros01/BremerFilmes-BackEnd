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

        public async Task<User> Cadastrar(User userorg)
        {
            await _context.Users.AddAsync(userorg);
            await _context.SaveChangesAsync();
            return userorg;
        }

        public User? GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username); // Busca o usuário no banco de dados
        }
    }
}
