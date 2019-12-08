using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaOfertas.Models.Compras;
using FrbaOfertas.Models.Clientes;

namespace FrbaOfertas.Models.Cupones
{
    public class Cupon
    {
        public int id_cupon { get; set; }
        public string cupon_codigo { get; set; }
        public System.DateTime cupon_fecha_deconsumo { get; set; }
        public decimal cupon_precio_oferta { get; set; }
        public decimal cupon_precio_lista { get; set; }
        public bool cupon_estado { get; set; }
        public Cliente consumidor { get; set; }
        public Compra compra { get; set; }

        public Cupon()
        {

        }
    }
}
