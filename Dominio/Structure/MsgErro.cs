using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Structure
{
    public static class MsgErro
    {
        public static string ErroRegistroNaoEncontrado = "Não foi encontrado registros.";
        public static string ErroCadastroBancoDados = "Erro ao executar cadastro no banco de dados.";
        public static string ErroConsultaBancoDados = "Erro ao executar consulta no banco de dados.";
        public static string ErroEdicaoBancoDados = "Erro ao executar edicao no banco de dados.";
        public static string ErroExcluirBancoDados = "Erro ao executar exclusão no banco de dados.";
        public static string ErroMapeamentoObjeto = "Erro na conversão do objeto de camadas diferentes.";
        public static string ErroParametroRecebido = "Os dados enviados para API estão inválidos";
    }
}
