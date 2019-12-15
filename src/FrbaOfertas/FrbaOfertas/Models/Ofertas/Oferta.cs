using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaOfertas.Models.Proveedores;

namespace FrbaOfertas.Models.Ofertas
{
    public class Oferta
    {
        public int id_oferta { get; set; }
        public string cod_oferta { get; set; }
        public string descripcion { get; set; }
        public System.DateTime fecha_inicio { get; set; }
        public System.DateTime fecha_fin { get; set; }
        public decimal precio_oferta { get; set; }
        public decimal precio_lista { get; set; }
        public int cantDisponible { get; set; }
        public int cant_max_porCliente { get; set; }
        public Proveedor proveedor { get; set; }

        public Oferta() 
        {
 
        }
    }
}
