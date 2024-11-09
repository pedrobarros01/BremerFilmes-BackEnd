using Domain.Model;
using Domain.Structure;
using Dominio.Model;
using Persistence.Context;
using Persistence.IRepository;
using System.Linq;

namespace Persistence.Repository
{
    public class PessoaFavoritaRepository : IPessoaFavoritaRepository
    {
        private readonly DataContext _context;

        public PessoaFavoritaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ResponseBase<PessoaFav>> CriarPessoaFavorita(PessoaFav pessoaFav)
        {
            try
            {
                ResponseBase<PessoaFav> response = new ResponseBase<PessoaFav>();
                pessoaFav.DtUserCreate = DateTime.UtcNow;
                await _context.PessoasFavoritas.AddAsync(pessoaFav);
                await _context.SaveChangesAsync();
                response.Status = true;
                response.Dados = pessoaFav;
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeletarPesssoaFavorita(int id)
        {
            try
            {
                PessoaFav? pessoaFav = _context.PessoasFavoritas.FirstOrDefault(r => r.Id == id);
                if (pessoaFav == null)
                {
                    return false;
                }
                _context.PessoasFavoritas.Remove(pessoaFav);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public ResponseBase<IList<PessoaFav>> PegarPessoasFavoritaPorUsuario(int idUsuario)
        {
            try
            {
                ResponseBase<IList<PessoaFav>> response = new ResponseBase<IList<PessoaFav>>();
                IList<PessoaFav> pessoaFavPorUsuario = _context.PessoasFavoritas.Where(p => p.IdUsuario == idUsuario).ToList();
                if (pessoaFavPorUsuario.Count == 0)
                {
                    response.Status = false;
                    response.Mensagem = "Esse usuário não tem nenhum ator ou diretor favorito";
                    return response;
                }
                response.Status = true;
                response.Dados = pessoaFavPorUsuario;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           

        }
    }
}
