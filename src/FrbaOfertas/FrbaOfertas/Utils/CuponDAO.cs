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
    public class CuponDAO
    {
      //  public List<Cupon> getCupones()
       // {

       //     return 
       // }

        public void entregarCupon(int id_cupon, int id_consumidor)
        {
            SqlCommand sp = FrbaOfertas.Utils.Database.createCommand("[GD2C2019].[T_REX].EntregarCupon");

            sp.Parameters.AddWithValue("id_cupon", id_cupon);
            sp.Parameters.AddWithValue("id_consumidor", id_consumidor);
            sp.Parameters.AddWithValue("fecha_consumo", Database.getDateBeta());
            
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
