using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaOfertas.Models.Facturas;
using System.Data.SqlClient;
using System.Data;

namespace FrbaOfertas.Utils
{
    public class FacturaDAO
    {
        public int? crearFactura(int idProveedor, DateTime fechaDesde, DateTime fechaHasta)
        {
            SqlCommand sp = FrbaOfertas.Utils.Database.createCommand("[GD2C2019].[T_REX].CrearFactura");

            sp.Parameters.AddWithValue("IdProveedor", idProveedor);
            sp.Parameters.AddWithValue("FechaDesde", fechaDesde);
            sp.Parameters.AddWithValue("FechaHasta", fechaHasta);

            SqlParameter Id = new SqlParameter("@IdOut", SqlDbType.Int);
            Id.Direction = ParameterDirection.Output;
            sp.Parameters.Add(Id);

            SqlParameter text = new SqlParameter("@out", SqlDbType.VarChar, 1000);
            text.Direction = ParameterDirection.Output;
            sp.Parameters.Add(text);

            FrbaOfertas.Utils.Database.executeProcedure(sp);

            if (!String.IsNullOrEmpty(text.Value.ToString()))
            {
                throw new Exception(text.Value.ToString());
            }

            if (Id != null)
            {
                return (int)Id.Value;
            }

            return null;
        }

        internal Factura getFactura(int? idFactura)
        {
            string cmd = "select id_factura, nro_factura, importe_fact, tipo_factura, fecha_inicio, fecha_fin from T_REX.FACTURA_PROVEEDOR WHERE id_factura=" + idFactura;

            SqlCommand command = FrbaOfertas.Utils.Database.createCommand(cmd);
            DataTable table = Utils.Database.getData(command);

            return table.Rows.Cast<DataRow>().
                Select(row =>
                {
                    return this.createFacturaFromQueryResult(row);
                }).ToList<Factura>()[0];
        }

        private Factura createFacturaFromQueryResult(DataRow row)
        {
            Factura factura = new Factura();

            factura.id_factura = int.Parse(row["id_factura"].ToString());
            factura.nro_factura = int.Parse(row["nro_factura"].ToString());
            factura.importe_fact = double.Parse(row["importe_fact"].ToString());
            factura.fecha_inicio = DateTime.Parse(row["fecha_inicio"].ToString());
            factura.fecha_fin = DateTime.Parse(row["fecha_fin"].ToString());
            factura.tipo_fact = row["tipo_factura"].ToString();

            return factura;
        }
    }
}
