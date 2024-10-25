using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // A senha deve ser armazenada de forma segura (hash)
        public bool Status { get; set; }
        public int? IdUserCreate { get; set; }
        public int? IdUserDelete { get; set; }
        public int? IdUserUpdate { get; set; }
        public DateTime? DtUserCreate { get; set; }
        public DateTime? DtUserDelete { get; set; }
        public DateTime? DtUserUpdate { get; set; }

    }
}
