using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaOfertas.Models.Ofertas;
using FrbaOfertas.Models.Clientes;

namespace FrbaOfertas.Models.Compras
{
    public class Compra
    {
        public int id_compra { get; set; }
        public System.DateTime compra_fecha { get; set; }
        public decimal cantidad { get; set; }
        public Cliente CLIENTE { get; set; }
        public Oferta OFERTA { get; set; }

        public Compra()
        {

        }
    }
}
