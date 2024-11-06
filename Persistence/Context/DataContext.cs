using Domain.Model;
using Dominio.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<ReviewFilme> ReviewFilmes { get; set; }
        public DbSet<FilmeFav> FilmesFavoritos { get; set; }
    }
}
