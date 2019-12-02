using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Models.Proveedores
{
    public class Proveedor
    {
        public int id { get; set; }
        public string razonSocial { get; set; }
        public string mail { get; set; }
        public int telefono { get; set; }
        public string CUIT { get; set; }
        public string rubro { get; set; }
        //public 

        public Proveedor ()
        {

        }
    }
}
