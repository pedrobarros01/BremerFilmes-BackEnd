﻿using Dominio.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class FilmeFavoritoViewModel : ModelBaseViewModel
    {
        public int IdFilmeTMDB { get; set; }
        public int IdUsuario { get; set; }

    }
}
