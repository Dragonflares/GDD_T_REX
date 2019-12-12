using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaOfertas.Models.Ofertas;

namespace FrbaOfertas.Models.Facturas
{
    public class ItemFactura
    {
        public int id_item_factura { get; set; }
        public Factura factura { get; set; }
        public Oferta oferta { get; set; }
        public int importe_oferta { get; set; }
        public int cantidad { get; set; }

        public ItemFactura() { }
    }
}
