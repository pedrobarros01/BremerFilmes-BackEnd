using Application.Dto;
using Application.IService;
using Application.ViewModel;
using AutoMapper;
using Domain.Model;
using Domain.Structure;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Persistence.IRepository;
using Persistence.Repository;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Service
{
    public class ReviewFilmeService : IReviewFilmeService
    {
        private IConfiguration _configuration;
        private IMapper _mapper;
        private IReviewFilmeRepository _repository;
        public ReviewFilmeService(IConfiguration configuration, IMapper mapper, IReviewFilmeRepository repository)
        {
            _configuration = configuration;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ResponseBaseViewModel<ReviewFilmeViewModel>> CriarReview(ReviewFilmeViewModel reviewFilme)
        {
            ResponseBaseViewModel<ReviewFilmeViewModel> responseBaseViewModel;
            try
            {
                ReviewFilme review = _mapper.Map<ReviewFilme>(reviewFilme);
                var response = await _repository.CriarReview(review);
                responseBaseViewModel = _mapper.Map<ResponseBaseViewModel<ReviewFilmeViewModel>>(response);
                return responseBaseViewModel;
            }
            catch (Exception e)
            {

                responseBaseViewModel = new ResponseBaseViewModel<ReviewFilmeViewModel>();
                responseBaseViewModel.Mensagem = MsgErro.ErroParametroRecebido;
                responseBaseViewModel.Descricao = e.Message;
                return responseBaseViewModel;
            }
           

        }

        public async Task<ResponseBaseViewModel<int>> DarCurtida(int id)
        {
            ResponseBaseViewModel<int> responseBaseViewModel;
            try
            {
                var response = await _repository.DarCurtida(id);
                responseBaseViewModel = _mapper.Map<ResponseBaseViewModel<int>>(response);
                return responseBaseViewModel;
            }
            catch (Exception ex)
            {

                responseBaseViewModel = new ResponseBaseViewModel<int>();
                responseBaseViewModel.Mensagem = MsgErro.ErroParametroRecebido;
                responseBaseViewModel.Descricao = ex.Message;
                return responseBaseViewModel;
            }
        }

        public async Task<ResponseBaseViewModel<bool>> DeletarReview(int id)
        {
            ResponseBaseViewModel<bool> responseBaseViewModel;
            try
            {
                var response = await _repository.DeletarReview(id);
                responseBaseViewModel = new ResponseBaseViewModel<bool>();
                responseBaseViewModel.Status = true;
                responseBaseViewModel.Dados = response;
                responseBaseViewModel.Mensagem = "Deletado com sucesso";
                return responseBaseViewModel;
            }
            catch (Exception ex)
            {

                responseBaseViewModel = new ResponseBaseViewModel<bool>();
                responseBaseViewModel.Mensagem = MsgErro.ErroParametroRecebido;
                responseBaseViewModel.Descricao = ex.Message;
                return responseBaseViewModel;
            }
        }

        public async Task<ResponseBaseViewModel<ReviewFilmeViewModel>> EditarComentario(ReviewEditDto editDto)
        {
            ResponseBaseViewModel<ReviewFilmeViewModel> responseBaseViewModel;
            try
            {
                var response = await _repository.EditarComentario(editDto.id, editDto.Comentario);
                responseBaseViewModel = _mapper.Map<ResponseBaseViewModel<ReviewFilmeViewModel>>(response);
                return responseBaseViewModel;
            }
            catch (Exception ex )
            {

                responseBaseViewModel = new ResponseBaseViewModel<ReviewFilmeViewModel>();
                responseBaseViewModel.Mensagem = MsgErro.ErroParametroRecebido;
                responseBaseViewModel.Descricao = ex.Message;
                return responseBaseViewModel;
            }
        }

        public ResponseBaseViewModel<ReviewFilmeViewModel> PegarReview(int id)
        {
            ResponseBaseViewModel<ReviewFilmeViewModel> responseBaseViewModel;
            try
            {
                var response =  _repository.PegarReview(id);
                responseBaseViewModel = _mapper.Map<ResponseBaseViewModel<ReviewFilmeViewModel>>(response);
                return responseBaseViewModel;
            }
            catch (Exception ex)
            {

                responseBaseViewModel = new ResponseBaseViewModel<ReviewFilmeViewModel>();
                responseBaseViewModel.Mensagem = MsgErro.ErroParametroRecebido;
                responseBaseViewModel.Descricao = ex.Message;
                return responseBaseViewModel;
            }
        }

        public ResponseBaseViewModel<IList<ReviewFilmeViewModel>> PegarReviews()
        {
            ResponseBaseViewModel<IList<ReviewFilmeViewModel>> responseBaseViewModel;
            try
            {
                var response = _repository.PegarReviews();
                responseBaseViewModel = _mapper.Map<ResponseBaseViewModel<IList<ReviewFilmeViewModel>>>(response);
                return responseBaseViewModel;
            }
            catch (Exception ex)
            {

                responseBaseViewModel = new ResponseBaseViewModel<IList<ReviewFilmeViewModel>>();
                responseBaseViewModel.Mensagem = MsgErro.ErroParametroRecebido;
                responseBaseViewModel.Descricao = ex.Message;
                return responseBaseViewModel;
            }
        }

        public ResponseBaseViewModel<IList<ReviewFilmeViewModel>> PegarReviewsPorUsuario(int idUsuario)
        {
            ResponseBaseViewModel<IList<ReviewFilmeViewModel>> responseBaseViewModel;
            try
            {
                var response = _repository.PegarReviewsPorUsuario(idUsuario);
                responseBaseViewModel = _mapper.Map<ResponseBaseViewModel<IList<ReviewFilmeViewModel>>>(response);
                return responseBaseViewModel;
            }
            catch (Exception ex)
            {

                responseBaseViewModel = new ResponseBaseViewModel<IList<ReviewFilmeViewModel>>();
                responseBaseViewModel.Mensagem = MsgErro.ErroParametroRecebido;
                responseBaseViewModel.Descricao = ex.Message;
                return responseBaseViewModel;
            }
        }
    }
}

