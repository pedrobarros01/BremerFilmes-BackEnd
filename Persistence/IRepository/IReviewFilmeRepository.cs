using Domain.Model;
using Domain.Structure;
using Dominio.Model;

namespace Persistence.IRepository
{
    public interface IReviewFilmeRepository
    {
        Task<ResponseBase<ReviewFilme>> CriarReview(ReviewFilme reviewFilme);
        Task<bool> DeletarReview(int id);
        Task<ResponseBase<int>> DarCurtida(int id);
        Task<ResponseBase<ReviewFilme>> EditarComentario(int id, string comentario);

        ResponseBase<IList<ReviewFilme>> PegarReviewsPorUsuario(int idUsuario);
        ResponseBase<IList<ReviewFilme>> PegarReviewsPorFilme(int idTmdbFilme);
        ResponseBase<IList<ReviewFilme>> PegarReviews();
        ResponseBase<ReviewFilme> PegarReview(int id);


    }
}
