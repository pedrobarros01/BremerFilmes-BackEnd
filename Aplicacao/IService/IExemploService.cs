using Application.Dto;
using Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface IExemploService
    {
        Task<ResponseBaseViewModel<List<ExemploViewModel>>> ConsultarExemploUsandoSQL();
        Task<ResponseBaseViewModel<List<ExemploViewModel>>> ConsultarExemploUsandoLinked();
        Task<ResponseBaseViewModel<ExemploViewModel>> ConsultarExemploPorId(int id);
        Task<ResponseBaseViewModel<ExemploViewModel>> CadastrarExemplo(ExemploDto exemploCadastroDto);
        Task<ResponseBaseViewModel<ExemploViewModel>> EditarExemplo(ExemploDto exemploEditarDto);
        Task<ResponseBaseViewModel<ExemploViewModel>> DesativarExemplo(int idExemplo);
    }
}
