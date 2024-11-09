using Application.Dto;
using Application.ViewModel;
using Domain.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface IReviewFilmeService
    {
        Task<ResponseBaseViewModel<ReviewFilmeViewModel>> CriarReview(ReviewCreateDto reviewFilme);
        Task<ResponseBaseViewModel<bool>> DeletarReview(int id);
        Task<ResponseBaseViewModel<int>> DarCurtida(int id);
        Task<ResponseBaseViewModel<ReviewFilmeViewModel>> EditarComentario(ReviewEditDto editDto);

        ResponseBaseViewModel<IList<ReviewFilmeViewModel>> PegarReviewsPorUsuario(int idUsuario);
        ResponseBaseViewModel<IList<ReviewFilmeViewModel>> PegarReviews();
        ResponseBaseViewModel<ReviewFilmeViewModel> PegarReview(int id);
    }
}
