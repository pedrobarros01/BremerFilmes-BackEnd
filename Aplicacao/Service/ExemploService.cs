using Application.Dto;
using Application.IService;
using Application.ViewModel;
using AutoMapper;
using Domain.Model;
using Domain.Structure;
using Newtonsoft.Json;
using Persistence.IRepository;
using Persistence.Repository;
using System.Collections.Generic;

namespace Application.Service
{
    public class ExemploService : IExemploService
    {
        private readonly IExemploRepository _exemploRepository;
        private readonly IMapper _mapper;

        public ExemploService(IExemploRepository exemploRepositoy, IMapper mapper)
        {
            _exemploRepository = exemploRepositoy;
            _mapper = mapper;
        }
        
        private bool ExemploValido(ExemploDto exemploDto)
        {
            if (exemploDto == null)
                return false;
            if (exemploDto.Dinheiro <= 0)
                return false;
            if (exemploDto.ValorDouble <= 0)
                return false;
            if (exemploDto.ValorFloat <= 0)
                return false;
            if (exemploDto.Nome.Trim().Length <= 0 ||
                exemploDto.Nome.Trim().Length > 200)
                return false;
            if (exemploDto.Descricao.Trim().Length <= 0 &&
                exemploDto.Descricao.Trim().Length > 400)
                return false;
            return true;
        }

        public async Task<ResponseBaseViewModel<ExemploViewModel>> CadastrarExemplo(ExemploDto exemploCadastroDto)
        {
            ResponseBaseViewModel<ExemploViewModel>? dataViewModel;

            if (!ExemploValido(exemploCadastroDto)) 
            {
                dataViewModel = new ResponseBaseViewModel<ExemploViewModel>();
                dataViewModel.Mensagem = MsgErro.ErroParametroRecebido;
                return dataViewModel;
            }

            try
            {
                Exemplo exemplo = _mapper.Map<Exemplo>(exemploCadastroDto);
                var response = await _exemploRepository.CadastrarExemplo(exemplo);
                dataViewModel = _mapper.Map<ResponseBaseViewModel<ExemploViewModel>>(response);
                return dataViewModel;
            }
            catch (Exception ex)
            {
                dataViewModel = new ResponseBaseViewModel<ExemploViewModel>();
                dataViewModel.Mensagem = MsgErro.ErroParametroRecebido;
                dataViewModel.Descricao = ex.Message;
                return dataViewModel;
            }
        }

        public async Task<ResponseBaseViewModel<ExemploViewModel>> ConsultarExemploPorId(int id)
        {
            ResponseBaseViewModel<ExemploViewModel>? dataViewModel;
            if(id <= 0)
            {
                dataViewModel = new ResponseBaseViewModel<ExemploViewModel>();
                dataViewModel.Mensagem = MsgErro.ErroParametroRecebido;
                return dataViewModel;
            }

            ResponseBase<Exemplo> dataDb = await _exemploRepository.ConsultarExemploPorId(id);
            try
            {
                ResponseBaseViewModel<ExemploViewModel> exemploViewModel = _mapper.Map<ResponseBaseViewModel<ExemploViewModel>>(dataDb);        
                if (exemploViewModel == null) throw new JsonSerializationException();
                dataViewModel = exemploViewModel;
                return dataViewModel;
            }
            catch (Exception ex)
            {
                dataViewModel = new ResponseBaseViewModel<ExemploViewModel>();
                dataViewModel.Mensagem = MsgErro.ErroMapeamentoObjeto;
                dataViewModel.Descricao = ex.Message;
                return dataViewModel;
            }
        }

        public async Task<ResponseBaseViewModel<List<ExemploViewModel>>> ConsultarExemploUsandoLinked()
        {
            ResponseBase<List<Exemplo>> dataDb = await _exemploRepository.ConsultarExemploUsandoLinked();
            ResponseBaseViewModel<List<ExemploViewModel>>? dataViewModel;

            try
            {
                ResponseBaseViewModel<List<ExemploViewModel>> exemploViewModel = _mapper.Map<ResponseBaseViewModel<List<ExemploViewModel>>>(dataDb);
                if (exemploViewModel == null) throw new JsonSerializationException();
                dataViewModel = exemploViewModel;
                return dataViewModel;
            }
            catch (Exception ex)
            {
                dataViewModel = new ResponseBaseViewModel<List<ExemploViewModel>>();
                dataViewModel.Mensagem = MsgErro.ErroMapeamentoObjeto;
                dataViewModel.Descricao = ex.Message;
                dataViewModel.Status = false;
                return dataViewModel;
            }
        }

        public async Task<ResponseBaseViewModel<List<ExemploViewModel>>> ConsultarExemploUsandoSQL()
        {
            ResponseBase<List<Exemplo>> dataDb = await _exemploRepository.ConsultarExemploUsandoSQL();
            ResponseBaseViewModel<List<ExemploViewModel>>? dataViewModel;
            
            try 
            {
                ResponseBaseViewModel<List<ExemploViewModel>> exemploViewModel = _mapper.Map<ResponseBaseViewModel<List<ExemploViewModel>>>(dataDb);
                if (exemploViewModel == null) throw new JsonSerializationException();
                dataViewModel = exemploViewModel;
                return dataViewModel;
            }
            catch (Exception ex) 
            {
                dataViewModel = new ResponseBaseViewModel<List<ExemploViewModel>>();
                dataViewModel.Mensagem = MsgErro.ErroMapeamentoObjeto;
                dataViewModel.Descricao = ex.Message;
                return dataViewModel;
            }
        }

        public async Task<ResponseBaseViewModel<ExemploViewModel>> EditarExemplo(ExemploDto exemploEditarDto)
        {
            ResponseBaseViewModel<ExemploViewModel>? dataViewModel;

            if (!ExemploValido(exemploEditarDto) || exemploEditarDto.Id <= 0)
            {
                dataViewModel = new ResponseBaseViewModel<ExemploViewModel>();
                dataViewModel.Mensagem = MsgErro.ErroParametroRecebido;
                return dataViewModel;
            }

            try
            {
                Exemplo exemplo = _mapper.Map<Exemplo>(exemploEditarDto);
                var response = await _exemploRepository.AtualizarExemplo(exemplo);
                dataViewModel = _mapper.Map<ResponseBaseViewModel<ExemploViewModel>>(response);
                return dataViewModel;
            }
            catch (Exception ex)
            {
                dataViewModel = new ResponseBaseViewModel<ExemploViewModel>();
                dataViewModel.Mensagem = MsgErro.ErroParametroRecebido;
                dataViewModel.Descricao = ex.Message;
                return dataViewModel;
            }
        }

        public async Task<ResponseBaseViewModel<ExemploViewModel>> DesativarExemplo(int idExemplo)
        {
            ResponseBaseViewModel<ExemploViewModel>? dataViewModel;
            if(idExemplo <= 0)
            {
                dataViewModel = new ResponseBaseViewModel<ExemploViewModel>();
                dataViewModel.Mensagem = MsgErro.ErroParametroRecebido;
                return dataViewModel;
            }
            try
            {
                var response = await _exemploRepository.DesativarExemplo(idExemplo);
                dataViewModel = _mapper.Map<ResponseBaseViewModel<ExemploViewModel>>(response);
                return dataViewModel;
            }
            catch (Exception ex)
            {
                dataViewModel = new ResponseBaseViewModel<ExemploViewModel>();
                dataViewModel.Mensagem = MsgErro.ErroParametroRecebido;
                dataViewModel.Descricao = ex.Message;
                return dataViewModel;
            }
        }

    }
}
