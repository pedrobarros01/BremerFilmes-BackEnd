using Domain.Model;
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

        public Task<ReviewFilme> CriarReview(ReviewFilme reviewFilme)
        {
            throw new NotImplementedException();
        }

        public Task<int> DarCurtida(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarReview(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewFilme> EditarComentario(int idUsuario, string comentario)
        {
            throw new NotImplementedException();
        }

        public ReviewFilme PegarReview(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ReviewFilme> PegarReviews()
        {
            throw new NotImplementedException();
        }

        public IList<ReviewFilme> PegarReviewsPorUsuario(int idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
