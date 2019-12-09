using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaOfertas.Models.Ofertas;
using FrbaOfertas.Models.Clientes;
using FrbaOfertas.Models.Cupones;

namespace FrbaOfertas.Models.Compras
{
    public class Compra
    {
        public int id_compra { get; set; }
        public System.DateTime compra_fecha { get; set; }
        public decimal cantidad { get; set; }
        public Cliente cliente { get; set; }
        public Oferta oferta { get; set; }
        public List<Cupon> cupones { get; set; }

        public Compra()
        {

        }
    }
}
