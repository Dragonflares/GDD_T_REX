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
    public class ItemFacturaDAO
    {
        public void crearItemFactura(ItemFactura itemFactura)
        {
            SqlCommand sp = FrbaOfertas.Utils.Database.createCommand("[GD2C2019].[T_REX].CrearItemFactura");

            sp.Parameters.AddWithValue("IdFactura", itemFactura.factura.id_factura);
            sp.Parameters.AddWithValue("Cantidad", itemFactura.cantidad);
            sp.Parameters.AddWithValue("Importe", itemFactura.importe_oferta);
            sp.Parameters.AddWithValue("IdOferta", itemFactura.oferta.id_oferta);


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
