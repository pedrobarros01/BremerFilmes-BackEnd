using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Structure
{
    public class ResponseBase<T>
    {
        public T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public bool Status { get; set; } = false;
    }
}
