using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ExemploDto
    {
        public int Id { get; set; }
        public decimal Dinheiro { get; set; }
        public double ValorDouble { get; set; }
        public float ValorFloat { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
