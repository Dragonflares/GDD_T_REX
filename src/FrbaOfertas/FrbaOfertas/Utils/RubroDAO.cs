using FrbaOfertas.Models.Rubros;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Utils
{
    class RubroDAO
    {
        public List<Rubro> getRubros() 
        {
            SqlCommand obtenerRubros = FrbaOfertas.Utils.Database.createCommand("SELECT r.id_rubro, r.nombreDeRubro FROM [GD2C2019].[T_REX].Rubro r ORDER BY r.nombreDeRubro");
            DataTable table = Utils.Database.getData(obtenerRubros);

            return table.Rows.Cast<DataRow>().
                Select(row =>
                {
                    return new Rubro(int.Parse(row["id_rubro"].ToString()), row["nombreDeRubro"].ToString());
                }).ToList<Rubro>();
        }
    }
}
