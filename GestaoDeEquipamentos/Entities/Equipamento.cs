using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeEquipamentos.Entities
{
    class Equipamento
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double PrecoAquisicao { get; set; }
        public string NumSerie { get; set; }
        public DateTime DataFabricacao { get; set; }
        public string Fabricante { get; set; }
    }
}
