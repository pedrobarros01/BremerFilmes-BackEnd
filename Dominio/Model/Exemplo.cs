using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Structure;

namespace Domain.Model
{
    [Table("Exemplo")] // Define o nome da tabela no banco de dados
    public class Exemplo : ModelBase
    {
        [Column(TypeName = "money")] // Define o tipo de dado na tabela gerado no SQL 
        public decimal Dinheiro { get; set; }
        public double ValorDouble { get; set; }
        public float ValorFloat { get; set; }
        [StringLength(200)] // Define o tamanho máximo da string
        public string Nome { get; set; }
        [StringLength(400)] // Define o tamanho máximo da string
        public string Descricao { get; set; }

    }
}
