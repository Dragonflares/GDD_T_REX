using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FrbaOfertas.Models.Roles;
using FrbaOfertas.Models.Funcionalidades;
using FrbaOfertas.Utils;
using System.Data;

namespace FrbaOfertas.Utils
{
    class RolDAO
    {
        public List<Funcionalidad> getFuncionalidades()
        {
            SqlCommand command = FrbaOfertas.Utils.Database.createCommand("SELECT [id_funcionalidad]" +
                ",[descripcion] FROM [GD1C2019].[T_REX].[Funcionalidad] ORDER BY [descripcion] ASC");
            DataTable table = Utils.Database.getData(command);

            return table.Rows.Cast<DataRow>().
                Select(row => new Funcionalidad(int.Parse(row["id_funcionalidad"].ToString()),
                    row["descripcion"].ToString())).ToList<Funcionalidad>();
           
        }

        public DataTable getFuncionalidades(Rol rol)
        {
            SqlCommand cmd = Database.createCommand("[T_REX].GetFuncionalidades");
            cmd.Parameters.Add("@rol_id",SqlDbType.Int).Value = rol.id;
            return Database.getDataProcedure(cmd);
        }


        public DataTable listarDatos()
        {
            SqlCommand cmd = Database.createCommand("SELECT nombre, estado FROM [GD1C2019].[T_REX].[Rol]");
            return Database.getData(cmd);
        }

        public DataTable getFuncionalidadesXRol(Rol rol)
        {
            SqlCommand cmd = Database.createCommand("SELECT f.descripcion FROM [GD2C2019].[T_REX].Funcionalidad f" +
                " JOIN [GD2C2019].[T_REX].Funcionalidad_Rol fr on fr.id_funcionalidad = f.id_funcionalidad" +
                " JOIN [GD2C2019].[T_REX].Rol r on r.id_rol = fr.id_rol WHERE r.nombre = @rol");
            cmd.Parameters.Add("@rol_id", SqlDbType.Int).Value = rol.id;
            return Database.getData(cmd);
        }

        public void updateRol(int id, String nombre, DataTable Funcionalidades)
        {

            SqlCommand cmd = Database.createCommand("[T_REX].UpdateRol");
            cmd.Parameters.Add("@rol_id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
            cmd.Parameters.Add("@funcionalidades", SqlDbType.Structured).Value = Funcionalidades;
            Database.executeProcedure(cmd);
        }

        public void borrar_rol(Rol rol)
        {

        }
    }
}
