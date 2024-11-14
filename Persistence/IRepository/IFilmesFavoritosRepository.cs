using Domain.Model;
using Domain.Structure;
using Dominio.Model;

namespace Persistence.IRepository
{
    public interface IFilmesFavoritosRepository
    {
        Task<ResponseBase<FilmeFav>> CriarFilmeFavorito(FilmeFav pessoaFav);
        Task<bool> DeletarFilmeFavorito(int id);
        ResponseBase<IList<FilmeFav>> PegarFilmesFavoritosPorUsuario(int idUsuario);

        ResponseBase<FilmeFav> PegarFilmeFavoritoPorUsuarioETMDB(int idUsuario, int idTMDB);


    }
}
