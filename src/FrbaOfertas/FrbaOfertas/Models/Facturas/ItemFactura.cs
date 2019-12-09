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
        int id_item_factura { get; set; }
        int id_factura { get; set; }
        Oferta oferta { get; set; }
        int importe_oferta { get; set; }
        int cantidad { get; set; }

        public ItemFactura() { }
    }
}
