using Domain.Model;
using Domain.Structure;
using Dominio.Model;
using Persistence.Context;
using Persistence.IRepository;
using System.Linq;

namespace Persistence.Repository
{
    public class FilmesFavoritosRepository : IFilmesFavoritosRepository
    {
        private readonly DataContext _context;

        public FilmesFavoritosRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ResponseBase<FilmeFav>> CriarFilmeFavorito(FilmeFav pessoaFav)
        {
            try
            {
                ResponseBase<FilmeFav> response = new ResponseBase<FilmeFav>();
                pessoaFav.DtUserCreate = DateTime.UtcNow;
                await _context.FilmesFavoritos.AddAsync(pessoaFav);
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

        public async Task<bool> DeletarFilmeFavorito(int id)
        {
            try
            {
                FilmeFav? filmeFav = _context.FilmesFavoritos.FirstOrDefault(r => r.Id == id);
                if (filmeFav == null)
                {
                    return false;
                }
                _context.FilmesFavoritos.Remove(filmeFav);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public ResponseBase<IList<FilmeFav>> PegarFilmesFavoritosPorUsuario(int idUsuario)
        {
            try
            {
                ResponseBase<IList<FilmeFav>> response = new ResponseBase<IList<FilmeFav>>();
                IList<FilmeFav> filmeFavPorUsuario = _context.FilmesFavoritos.Where(p => p.IdUsuario == idUsuario).ToList();
                if (filmeFavPorUsuario.Count == 0)
                {
                    response.Status = false;
                    response.Mensagem = "Esse usuário não tem nenhum filme favorito";
                    return response;
                }
                response.Status = true;
                response.Dados = filmeFavPorUsuario;
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           

        }
    }
}
