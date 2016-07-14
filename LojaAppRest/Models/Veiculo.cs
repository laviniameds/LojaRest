using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaAppRest.Models
{
    class Veiculo
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public int IdFabricante { get; set; }
        public DateTime DataCompra { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal PrecoVenda { get; set; }
        public DateTime DataVenda { get; set; }
        public decimal ValorVenda { get; set; }
    }
}
