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
            List<Compra> comprasRealizadas = getComprasPorOferta(fecha_inicio, fecha_fin, id_oferta);
            int counter = 0;
            foreach (Compra compra in comprasRealizadas)
            {
                counter += compra.cantidad;
            }
            return counter;
        }

        public int cantidadDeOfertasCompradasPorEsteCliente(int id_oferta, int id_cliente)
        {
            List<Compra> comprasRealizadas = getComprasPorCliente(id_oferta, id_cliente);
            int counter = 0;
            foreach (Compra compra in comprasRealizadas)
            {
                counter += compra.cantidad;
            }
            return counter;
        }

        public int recaudacionTotalOfertaEnPeriodo(DateTime fecha_inicio, DateTime fecha_fin, Oferta oferta)
        {
            int cantidadComprasRealizadas = cantidadDeUnaOfertaCompradasEnPeriodo(fecha_inicio, fecha_fin, oferta.id_oferta);

            return (oferta.precio_oferta * cantidadComprasRealizadas);
        }

        public List<Compra> getComprasPorOferta(DateTime fecha_inicio, DateTime fecha_fin, int id_oferta)
        {
            string cmd = "SELECT c.id_compra, c.compra_fecha, c.id_oferta, c.id_cliente, c.cantidad" +
                "FROM [GD2C2019].[T_REX].[Compra] c " +
                "WHERE 1=1 and c.id_oferta = " + id_oferta + "and c.compra_fecha between " + fecha_inicio + " and " + fecha_fin;


            cmd += "ORDER BY c.[id_compra] ASC";

            SqlCommand command = FrbaOfertas.Utils.Database.createCommand(cmd);
            DataTable table = Utils.Database.getData(command);

            return table.Rows.Cast<DataRow>().
                Select(row =>
                {
                    return this.createCompraFromQueryResult(row);
                }).ToList<Compra>();
            
        }

        

        public List<Compra> getComprasPorCliente(int id_oferta, int id_cliente)
        {
            string cmd = "SELECT c.id_compra, c.compra_fecha, c.id_oferta, c.id_cliente, c.cantidad " +
                "FROM [GD2C2019].[T_REX].[Compra] c " +
                "WHERE 1=1 and c.id_cliente = " + id_cliente + " and c.id_oferta = " + id_oferta + " ";


            cmd += "ORDER BY c.[id_compra] ASC";

            SqlCommand command = FrbaOfertas.Utils.Database.createCommand(cmd);
            DataTable table = Utils.Database.getData(command);

            return table.Rows.Cast<DataRow>().
                Select(row =>
                {
                    return this.createCompraFromQueryResult(row);
                }).ToList<Compra>();
        }


        private Compra createCompraFromQueryResult(DataRow row)
        {
            Compra compra = new Compra();
            compra.id_compra = int.Parse(row["id_compra"].ToString());
            compra.cantidad = int.Parse(row["cantidad"].ToString());
            return compra;
        }

        public void guardarCompra(Compra compra)
        {
            SqlCommand sp = FrbaOfertas.Utils.Database.createCommand("[GD2C2019].[T_REX].CrearOferta");

            sp.Parameters.AddWithValue("Id_Oferta", compra.oferta.id_oferta);
            sp.Parameters.AddWithValue("Id_Cliente", compra.cliente.id);
            sp.Parameters.AddWithValue("Fecha", compra.compra_fecha);
            sp.Parameters.AddWithValue("Cantidad", compra.cantidad);

            SqlParameter text = new SqlParameter("@out", SqlDbType.VarChar, 1000);
            text.Direction = ParameterDirection.Output;
            sp.Parameters.Add(text);

            FrbaOfertas.Utils.Database.executeProcedure(sp);

            if (!String.IsNullOrEmpty(text.Value.ToString()))
            {
                throw new Exception(text.Value.ToString());
            }
        }
    }
}
