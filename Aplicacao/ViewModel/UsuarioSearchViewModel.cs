using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class UsuarioSearchViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime? DtUserCreate { get; set; }
        public string Localizacao { get; set; }
        public string Descricao { get; set; }

    }
}
