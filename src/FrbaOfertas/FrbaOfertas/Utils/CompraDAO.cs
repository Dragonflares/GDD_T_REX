using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using FrbaOfertas.Models.Ofertas;
using FrbaOfertas.Models;
using FrbaOfertas.Models.Cupones;
using FrbaOfertas.Models.Compras;
using System.Data.SqlTypes;

namespace FrbaOfertas.Utils
{
    public class CompraDAO
    {
        //Yo las compras lo que las voy a necesitar
        //Es para que me den su cantidad de determinada Oferta
        //Comprada en determinado intervalor.
        //Eso significa, que solo necesito obtener la cantidad, no necesariamente todo el caho
        //Puedo pedir todo el cacho igual. Hacer un mapeo, uan sumatoria, y ver que onda

        public int cantidadDeUnaOfertaCompradasEnPeriodo(DateTime fecha_inicio, DateTime fecha_fin, int id_oferta)
        {
            List<Compra> comprasRealizadas = getCompras(fecha_inicio, fecha_fin, id_oferta);
            return 0;
        }

        public int recaudacionTotalOfertaEnPeriodo(DateTime fecha_inicio, DateTime fecha_fin, int id_oferta)
        {
            List<Compra> comprasRealizadas = getCompras(fecha_inicio, fecha_fin, id_oferta);
            return 0;
        }

        public List<Compra> getCompras(DateTime fecha_inicio, DateTime fecha_fin, int id_oferta)
        {

            return null;
        }
    }
}
