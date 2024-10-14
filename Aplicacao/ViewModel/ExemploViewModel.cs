using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class ExemploViewModel
    {
        public int Id { get; set; } 
        public bool Status { get; set; }
        public decimal Dinheiro { get; set; }
        public double ValorDouble { get; set; }
        public float ValorFloat { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

    }
}
