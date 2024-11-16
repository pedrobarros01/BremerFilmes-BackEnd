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

        public ResponseBase<IList<PessoaFav>> PegarAtoresFavoritosPorUsuario(int idUsuario)
        {
            try
            {
                ResponseBase<IList<PessoaFav>> response = new ResponseBase<IList<PessoaFav>>();
                IList<PessoaFav> pessoaFavPorUsuario = _context.PessoasFavoritas.Where(p => p.IdUsuario == idUsuario && p.Cargo == "Acting").ToList();
                if (pessoaFavPorUsuario.Count == 0)
                {
                    response.Status = false;
                    response.Mensagem = "Esse usuário não tem nenhum ator favorito";
                    response.Descricao = "404";
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


        public ResponseBase<IList<PessoaFav>> PegarDiretoresFavoritosPorUsuario(int idUsuario)
        {
            try
            {
                ResponseBase<IList<PessoaFav>> response = new ResponseBase<IList<PessoaFav>>();
                IList<PessoaFav> pessoaFavPorUsuario = _context.PessoasFavoritas.Where(p => p.IdUsuario == idUsuario && p.Cargo == "Directing").ToList();
                if (pessoaFavPorUsuario.Count == 0)
                {
                    response.Status = false;
                    response.Mensagem = "Esse usuário não tem nenhum diretor favorito";
                    response.Descricao = "404";
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

        public ResponseBase<PessoaFav> PegarPessoaFavoritaPorUsuarioETMDB(int idUsuario, int idPessoaTmdb, string cargo)
        {
            try
            {
                ResponseBase<PessoaFav> response = new ResponseBase<PessoaFav>();
                PessoaFav? pessoaFavPorUsuario = _context.PessoasFavoritas.FirstOrDefault(p => p.IdUsuario == idUsuario && p.IdPessoaTMDB == idPessoaTmdb && p.Cargo == cargo);
                if (pessoaFavPorUsuario == null)
                {
                    response.Status = false;
                    response.Mensagem = "Esse usuário não tem nenhum ator favorito";
                    response.Descricao = "404";
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
                    response.Descricao = "404";
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
