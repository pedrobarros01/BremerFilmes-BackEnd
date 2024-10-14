using Microsoft.EntityFrameworkCore;
using Persistence.IRepository;
using Persistence.Context;
using Domain.Model;
using Domain.Structure;

namespace Persistence.Repository
{
    public class ExemploRepository : IExemploRepository
    {
        private readonly DataContext _context;
        public ExemploRepository(DataContext dataContext) 
        {
            _context = dataContext;
        }

        public async Task<ResponseBase<Exemplo>> ConsultarExemploPorId(int id)
        {
            ResponseBase<Exemplo> response = new ResponseBase<Exemplo>();
            try
            {
                //Operação no Banco de dados
                var data = await _context.DB_Exemplo.FirstOrDefaultAsync(x => x.Id == id);

                //Verifica se foi encontrado registros na consulta
                if (data == null)
                {
                    response.Mensagem = MsgErro.ErroRegistroNaoEncontrado;
                    return response;
                }

                //Retorno do método
                response.Dados = data;
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = MsgErro.ErroConsultaBancoDados;
                response.Descricao = ex.Message;
                return response;
            }
        }

        public async Task<ResponseBase<List<Exemplo>>> ConsultarExemploUsandoLinked()
        {
            ResponseBase<List<Exemplo>> response = new ResponseBase<List<Exemplo>>();
            try
            {
                //Operação no Banco de dados
                var data = await _context.DB_Exemplo.ToListAsync();

                //Verifica se foi encontrado registros na consulta
                if (data == null || data.Count() <= 0)
                {
                    response.Mensagem = MsgErro.ErroRegistroNaoEncontrado;
                    return response;
                }

                //Retorno do método
                response.Dados = data;
                response.Status = true;
                return response;
            }
            catch (Exception ex) 
            {
                response.Mensagem = MsgErro.ErroConsultaBancoDados;
                response.Descricao = ex.Message;
                return response;
            }
        }

        public async Task<ResponseBase<List<Exemplo>>> ConsultarExemploUsandoSQL()
        {
            ResponseBase<List<Exemplo>> response = new ResponseBase<List<Exemplo>>();
            try
            {
                //Operação no Banco de dados
                var data = await _context.DB_Exemplo.FromSqlRaw("SELECT * FROM Exemplo (nolock)").ToListAsync();

                //Verifica se foi encontrado registros na consulta
                if (data == null || data.Count() <= 0)
                {
                    response.Mensagem = MsgErro.ErroRegistroNaoEncontrado;
                    return response;
                }

                //Retorno do método
                response.Dados = data;
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = MsgErro.ErroConsultaBancoDados;
                response.Descricao = ex.Message;
                return response;
            }
        }
        
        public async Task<ResponseBase<Exemplo>> CadastrarExemplo(Exemplo exemplo)
        {
            ResponseBase<Exemplo> response = new ResponseBase<Exemplo>();

            try
            {
                exemplo.IdUserCreate = 0;
                exemplo.DtUserCreate = DateTime.Now;
                exemplo.Status = true;

                await _context.DB_Exemplo.AddAsync(exemplo);
                if (_context.SaveChanges() <= 0) throw new Exception();
                response.Status = true;
                response.Dados = exemplo;
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = MsgErro.ErroCadastroBancoDados;
                response.Descricao = ex.Message;
                return response;
            }
        }
        
        public async Task<ResponseBase<Exemplo>> AtualizarExemplo(Exemplo exemplo)
        {
            ResponseBase<Exemplo> response = new ResponseBase<Exemplo>();
            try
            {
                var data = await _context.DB_Exemplo.FirstOrDefaultAsync(x => x.Id == exemplo.Id);
                if (data == null)
                {
                    response.Mensagem = MsgErro.ErroRegistroNaoEncontrado;
                    return response;
                }
                data.IdUserUpdate = 0;
                data.DtUserUpdate = DateTime.Now;
                data.Descricao = exemplo.Descricao != data.Descricao ? exemplo.Descricao : data.Descricao;
                data.Nome = exemplo.Nome != data.Nome ? exemplo.Nome : data.Nome;
                data.Dinheiro = exemplo.Dinheiro != data.Dinheiro ? exemplo.Dinheiro : data.Dinheiro;
                data.ValorDouble = exemplo.ValorDouble != data.ValorDouble ? exemplo.ValorDouble : data.ValorDouble;
                data.ValorFloat = exemplo.ValorFloat != data.ValorFloat ? exemplo.ValorFloat : data.ValorFloat;
                _context.Update(data);

                if (_context.SaveChanges() <= 0) throw new Exception();
                response.Status = true;
                response.Dados = data;
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = MsgErro.ErroEdicaoBancoDados;
                response.Descricao = ex.Message;
                return response;
            }
        }

        public async Task<ResponseBase<Exemplo>> DesativarExemplo(int idExemplo)
        {
            ResponseBase<Exemplo> response = new ResponseBase<Exemplo>();
            try
            {
                var data = await _context.DB_Exemplo.FirstOrDefaultAsync(x => x.Id == idExemplo);
                if (data == null)
                {
                    response.Mensagem = MsgErro.ErroRegistroNaoEncontrado;
                    return response;
                }
                data.Status = false;
                data.IdUserDelete = 0;
                data.DtUserDelete = DateTime.Now;

                _context.Update(data);
                if (_context.SaveChanges() <= 0) throw new Exception();
                response.Status = true;
                response.Dados = data;

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = MsgErro.ErroEdicaoBancoDados;
                response.Descricao = ex.Message;
                return response;
            }
        }
    }
}
