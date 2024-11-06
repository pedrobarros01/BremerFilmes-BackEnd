using Domain.Structure;
using Dominio.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ReviewFilme : ModelBase
    {
        public int IdFilmeTMDB { get; set; }
        [ForeignKey("User")]
        public int IdUsuario { get; set; }
        public User Usuario { get; set; }
        public string Comentario { get; set; }
        public decimal Nota { get; set; }
        public int Curtidas { get; set; }

        
    }
}
