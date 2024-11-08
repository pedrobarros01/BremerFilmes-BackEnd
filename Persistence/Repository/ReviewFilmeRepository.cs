using Domain.Model;
using Domain.Structure;
using Dominio.Model;
using Persistence.Context;
using Persistence.IRepository;

using System.Linq;

namespace Persistence.Repository
{
    public class ReviewFilmeRepository : IReviewFilmeRepository
    {
        private readonly DataContext _context;

        public ReviewFilmeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ResponseBase<ReviewFilme>> CriarReview(ReviewFilme reviewFilme)
        {
            try
            {
                ResponseBase<ReviewFilme> response = new ResponseBase<ReviewFilme>();
                reviewFilme.DtUserCreate = DateTime.UtcNow;
                await _context.ReviewFilmes.AddAsync(reviewFilme);
                await _context.SaveChangesAsync();
                response.Status = true;
                response.Dados = reviewFilme;
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<ResponseBase<int>> DarCurtida(int id)
        {
            ReviewFilme? reviewFilme = _context.ReviewFilmes.FirstOrDefault(r => r.Id == id);
            ResponseBase<int> response = new ResponseBase<int>();
            if ( reviewFilme == null)
            {
                response.Status = false;
                response.Dados = -1;
                response.Descricao = "Erro em achar review de filme(id invalido)";
                return response;
            }
            reviewFilme.Curtidas += 1;
            _context.ReviewFilmes.Update(reviewFilme);
            await _context.SaveChangesAsync();
            response.Dados = reviewFilme.Curtidas;
            response.Status = true;
            return response;

        }

        public async Task<bool> DeletarReview(int id)
        {
            ReviewFilme? reviewFilme = _context.ReviewFilmes.FirstOrDefault(r => r.Id == id);
            if ( reviewFilme == null)
            {
                return false;
            }
            _context.ReviewFilmes.Remove(reviewFilme);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<ResponseBase<ReviewFilme>> EditarComentario(int id, string comentario)
        {
            ReviewFilme? reviewFilme = _context.ReviewFilmes.FirstOrDefault(r => r.Id == id);
            ResponseBase<ReviewFilme> response = new ResponseBase<ReviewFilme>();

            if (reviewFilme == null)
            {
                response.Status = false;
                response.Dados = null;
                response.Descricao = "Erro em achar review de filme(id invalido)";
                return response;
            }
            reviewFilme.Comentario = comentario;
            _context.ReviewFilmes.Update(reviewFilme);
            await _context.SaveChangesAsync();
            response.Status = true;
            response.Dados = reviewFilme;
            return response;
        }

        public ResponseBase<ReviewFilme> PegarReview(int id)
        {
            ReviewFilme? review = _context.ReviewFilmes.FirstOrDefault(r => r.Id == id);
            ResponseBase<ReviewFilme> response = new ResponseBase<ReviewFilme>();
            if (review == null)
            {
                response.Status= false;
                response.Dados = null;
                response.Descricao = "Não existe essa review";
                return response;
            }
            response.Status = true;
            response.Dados = review;
            return response;

        }

        public ResponseBase<IList<ReviewFilme>> PegarReviews()
        {
            ResponseBase<IList<ReviewFilme>> response = new ResponseBase<IList<ReviewFilme>>();
            IList<ReviewFilme> reviews = _context.ReviewFilmes.ToList();
            response.Status = true;
            response.Dados = reviews;
            return response;
        }

        public ResponseBase<IList<ReviewFilme>> PegarReviewsPorUsuario(int idUsuario)
        {
            ResponseBase<IList<ReviewFilme>> response = new ResponseBase<IList<ReviewFilme>>();
            IList<ReviewFilme> reviews = _context.ReviewFilmes.Where(r => r.IdUsuario == idUsuario).ToList();
            response.Status = true;
            response.Dados = reviews;
            return response;
        }
    }
}
