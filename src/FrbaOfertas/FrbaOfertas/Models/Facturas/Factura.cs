using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaOfertas.Models.Proveedores;

namespace FrbaOfertas.Models.Facturas
{
    public class Factura
    {
        public int id_factura { get; set; }
        public int nro_factura { get; set; }
        public double importe_fact { get; set; }
        public string tipo_fact { get; set; }
        public System.DateTime fecha_inicio { get; set; }
        public System.DateTime fecha_fin { get; set; }
        public Proveedor proveedor { get; set; }
        public List<ItemFactura> items { get; set; }
    }
}
