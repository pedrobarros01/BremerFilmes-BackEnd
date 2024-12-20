using Domain.Model;
using Domain.Structure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Model
{
    public class User : ModelBase
    {
        public string? Localizacao { get; set; }
        public string? Descricao { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        public string PasswordHash { get; set; } // A senha deve ser armazenada de forma segura (hash)

        public IList<ReviewFilme> ReviewFilmes { get; set; }
        public IList<FilmeFav> FilmeFavoritos { get; set; }
        public IList<PessoaFav> PessoasFavoritas { get; set; }

    }
}
