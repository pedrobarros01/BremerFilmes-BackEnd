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
    public interface IPessoaFavoritaService
    {
        Task<ResponseBaseViewModel<PessoaFavoritaViewModel>> CriarPessoaFavorita(PessoaFavCreateDto pessoaFav);
        Task<ResponseBaseViewModel<bool>> DeletarPesssoaFavorita(int id);
        ResponseBaseViewModel<IList<PessoaFavoritaViewModel>> PegarPessoasFavoritaPorUsuario(int idUsuario);
    }
}
