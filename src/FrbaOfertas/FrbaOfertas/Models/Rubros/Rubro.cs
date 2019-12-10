using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Models.Rubros
{
    class Rubro
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public Rubro(int id, string nombre) 
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}
