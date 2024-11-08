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
    public class FilmeFav : ModelBase
    {
        public int IdFilmeTMDB { get; set; }
        public User User { get; set; }

        [ForeignKey("User")]
        public int IdUsuario { get; set; }
        
    }
}
