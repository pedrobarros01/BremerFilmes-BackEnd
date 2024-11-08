using Domain.Model;
using Dominio.Model;

namespace Persistence.IRepository
{
    public interface IReviewFilmeRepository
    {
        Task<ReviewFilme> CriarReview(ReviewFilme reviewFilme);
        Task<bool> DeletarReview(int id);
        Task<int> DarCurtida(int idUsuario);
        Task<ReviewFilme> EditarComentario(int idUsuario, string comentario);

        IList<ReviewFilme> PegarReviewsPorUsuario(int idUsuario);
        IList<ReviewFilme> PegarReviews();
        ReviewFilme PegarReview(int id);


    }
}
