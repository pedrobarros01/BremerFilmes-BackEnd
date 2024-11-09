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
    public class PessoaFavoritaService : IPessoaFavoritaService
    {
        private IConfiguration _configuration;
        private IMapper _mapper;
        private IPessoaFavoritaRepository _repository;
        public PessoaFavoritaService(IConfiguration configuration, IMapper mapper, IPessoaFavoritaRepository repository)
        {
            _configuration = configuration;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ResponseBaseViewModel<PessoaFavoritaViewModel>> CriarPessoaFavorita(PessoaFavCreateDto pessoaFav)
        {
            ResponseBaseViewModel<PessoaFavoritaViewModel> responseViewModel;
            try
            {
                PessoaFavoritaViewModel pessoaFavorita = _mapper.Map<PessoaFavoritaViewModel>(pessoaFav);
                PessoaFav pessoaFav1 = _mapper.Map<PessoaFav>(pessoaFavorita);
                var response = await _repository.CriarPessoaFavorita(pessoaFav1);
                responseViewModel = _mapper.Map<ResponseBaseViewModel<PessoaFavoritaViewModel>>(response);
                return responseViewModel;
            }
            catch (Exception ex)
            {
                responseViewModel = new ResponseBaseViewModel<PessoaFavoritaViewModel>();
                responseViewModel.Status = false;
                responseViewModel.Mensagem = ex.Message;
                return responseViewModel;
                
            }
        }

        public async Task<ResponseBaseViewModel<bool>> DeletarPesssoaFavorita(int id)
        {
            ResponseBaseViewModel<bool> responseViewModel;
            try
            {
                bool deletado = await _repository.DeletarPesssoaFavorita(id);
                responseViewModel = new ResponseBaseViewModel<bool>();
                if (!deletado)
                {
                    responseViewModel.Status = false;
                    responseViewModel.Dados = false;
                    responseViewModel.Mensagem = "Não conseguimos deletar essa pessoa favorita";
                    return responseViewModel;
                }
                responseViewModel.Status=true;
                responseViewModel.Dados = true;
                responseViewModel.Mensagem = "Deletado com sucesso";
                return responseViewModel;
            }
            catch (Exception ex)
            {
                responseViewModel = new ResponseBaseViewModel<bool>();
                responseViewModel.Status = false;
                responseViewModel.Mensagem = ex.Message;
                return responseViewModel;

            }
        }

        public ResponseBaseViewModel<IList<PessoaFavoritaViewModel>> PegarPessoasFavoritaPorUsuario(int idUsuario)
        {
            ResponseBaseViewModel<IList<PessoaFavoritaViewModel>> responseViewModel;
            try
            {
                var response = _repository.PegarPessoasFavoritaPorUsuario(idUsuario);
                responseViewModel = _mapper.Map<ResponseBaseViewModel<IList<PessoaFavoritaViewModel>>>(response);
                return responseViewModel;
            }
            catch (Exception ex)
            {

                responseViewModel = new ResponseBaseViewModel<IList<PessoaFavoritaViewModel>>();
                responseViewModel.Status = false;
                responseViewModel.Mensagem = ex.Message;
                return responseViewModel;
            }
        }
    }
}

