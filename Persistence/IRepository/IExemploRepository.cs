using Domain.Model;
using Domain.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.IRepository
{
    public interface IExemploRepository
    {
        Task<ResponseBase<Exemplo>> ConsultarExemploPorId(int id);

        Task<ResponseBase<List<Exemplo>>> ConsultarExemploUsandoLinked();

        Task<ResponseBase<List<Exemplo>>> ConsultarExemploUsandoSQL();

        Task<ResponseBase<Exemplo>> CadastrarExemplo(Exemplo exemplo);

        Task<ResponseBase<Exemplo>> AtualizarExemplo(Exemplo exemplo);

        Task<ResponseBase<Exemplo>> DesativarExemplo(int idExemplo);
    }
}
