using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class ResponseBaseViewModel<T>
    {
        public T? Dados { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public bool Status { get; set; } = false;
    }
}
