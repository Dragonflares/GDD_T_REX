using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaOfertas.Models.Usuarios;

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
        public Usuario usuario { get; set; }
        public Direccion direccion { get; set; }
        public bool estado { get; set; }

        public Proveedor ()
        {

        }
    }
}
