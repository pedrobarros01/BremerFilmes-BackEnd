using Application.Dto;
using Application.ViewModel;
using Domain.Model;
using Domain.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface IFilmesFavoritosService
    {
        Task<ResponseBaseViewModel<FilmeFavoritoViewModel>> CriarFilmeFavorito(FilmeFavCreateDto filmeFav);
        Task<ResponseBaseViewModel<bool>> DeletarFilmeFavorito(int id);
        ResponseBaseViewModel<IList<FilmeFavoritoViewModel>> PegarFilmesFavoritosPorUsuario(int idUsuario);
        ResponseBaseViewModel<FilmeFavoritoViewModel> PegarFilmeFavoritoPorUsuarioETMDB(int idUsuario, int idTMDB);
    }
}
