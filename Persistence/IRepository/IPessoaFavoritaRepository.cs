using Domain.Model;
using Domain.Structure;
using Dominio.Model;

namespace Persistence.IRepository
{
    public interface IPessoaFavoritaRepository
    {
        
        Task<ResponseBase<PessoaFav>> CriarPessoaFavorita(PessoaFav pessoaFav);
        Task<bool> DeletarPesssoaFavorita(int id);
        ResponseBase<IList<PessoaFav>> PegarPessoasFavoritaPorUsuario(int idUsuario);
        ResponseBase<IList<PessoaFav>> PegarDiretoresFavoritosPorUsuario(int idUsuario);
        ResponseBase<IList<PessoaFav>> PegarAtoresFavoritosPorUsuario(int idUsuario);
        ResponseBase<PessoaFav> PegarPessoaFavoritaPorUsuarioETMDB(int idUsuario, int idPessoaTmdb, string cargo);

    }
}
