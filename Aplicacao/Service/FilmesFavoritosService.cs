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
    public class FilmesFavoritosService : IFilmesFavoritosService
    {
        private IConfiguration _configuration;
        private IMapper _mapper;
        private IFilmesFavoritosRepository _repository;
        public FilmesFavoritosService(IConfiguration configuration, IMapper mapper, IFilmesFavoritosRepository repository)
        {
            _configuration = configuration;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ResponseBaseViewModel<FilmeFavoritoViewModel>> CriarFilmeFavorito(FilmeFavCreateDto filmeFav)
        {
            ResponseBaseViewModel<FilmeFavoritoViewModel> responseViewModel;
            try
            {
                FilmeFavoritoViewModel filmeFavorito = _mapper.Map<FilmeFavoritoViewModel>(filmeFav);
                FilmeFav filmeFav1 = _mapper.Map<FilmeFav>(filmeFavorito);
                var response = await _repository.CriarFilmeFavorito(filmeFav1);
                responseViewModel = _mapper.Map<ResponseBaseViewModel<FilmeFavoritoViewModel>>(response);
                return responseViewModel;
            }
            catch (Exception ex)
            {
                responseViewModel = new ResponseBaseViewModel<FilmeFavoritoViewModel>();
                responseViewModel.Status = false;
                responseViewModel.Mensagem = ex.Message;
                return responseViewModel;
                
            }
        }

        public async Task<ResponseBaseViewModel<bool>> DeletarFilmeFavorito(int id)
        {
            ResponseBaseViewModel<bool> responseViewModel;
            try
            {
                bool deletado = await _repository.DeletarFilmeFavorito(id);
                responseViewModel = new ResponseBaseViewModel<bool>();
                if (!deletado)
                {
                    responseViewModel.Status = false;
                    responseViewModel.Dados = false;
                    responseViewModel.Mensagem = "Não conseguimos deletar esse filme favorito";
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

        public ResponseBaseViewModel<IList<FilmeFavoritoViewModel>> PegarFilmesFavoritosPorUsuario(int idUsuario)
        {
            ResponseBaseViewModel<IList<FilmeFavoritoViewModel>> responseViewModel;
            try
            {
                var response = _repository.PegarFilmesFavoritosPorUsuario(idUsuario);
                responseViewModel = _mapper.Map<ResponseBaseViewModel<IList<FilmeFavoritoViewModel>>>(response);
                return responseViewModel;
            }
            catch (Exception ex)
            {

                responseViewModel = new ResponseBaseViewModel<IList<FilmeFavoritoViewModel>>();
                responseViewModel.Status = false;
                responseViewModel.Mensagem = ex.Message;
                return responseViewModel;
            }
        }
    }
}

