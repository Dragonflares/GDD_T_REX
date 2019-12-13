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
        public Rol getRol(string rol)
        {
            string cmd = "SELECT r.[id_rol], r.[nombre]" +
                " FROM [GD2C2019].[T_REX].[Rol] r" +
                " WHERE r.nombre = '" + rol + "'";

            SqlCommand command = FrbaOfertas.Utils.Database.createCommand(cmd);
            DataTable table = Utils.Database.getData(command);

            return table.Rows.Cast<DataRow>().
                Select(row =>
                {
                    return this.createRolFromQueryResult(row);
                }).ToList<Rol>()[0];
        }

        public Rol getRolxID(int id_rol)
        {
            string cmd = "SELECT r.[id_rol], r.[nombre]" +
                " FROM [GD2C2019].[T_REX].[Rol] r" +
                " WHERE r.id_rol = " + id_rol + "";

            SqlCommand command = FrbaOfertas.Utils.Database.createCommand(cmd);
            DataTable table = Utils.Database.getData(command);

            return table.Rows.Cast<DataRow>().
                Select(row =>
                {
                    return this.createRolFromQueryResult(row);
                }).ToList<Rol>()[0];
        }

        private Rol createRolFromQueryResult(DataRow row)
        {
            Rol rol = new Rol(int.Parse(row["id_rol"].ToString()),
                row["nombre"].ToString());
            return rol;
        }

        public List<Funcionalidad> getFuncionalidades()
        {
            SqlCommand command = FrbaOfertas.Utils.Database.createCommand("SELECT [id_funcionalidad] as id" +
                ",[descripcion] as Funcionalidad FROM [GD2C2019].[T_REX].[Funcionalidad] ORDER BY [descripcion] ASC");
            DataTable table = Utils.Database.getData(command);

            return table.Rows.Cast<DataRow>().
                Select(row => new Funcionalidad(int.Parse(row["id"].ToString()),
                    row["Funcionalidad"].ToString())).ToList<Funcionalidad>();
           
        }

        public DataTable getFuncionalidades(int rol)
        {
            SqlCommand cmd = Database.createCommand("SELECT f.id_funcionalidad as id, f.descripcion as Funcionalidad" +
                " FROM [GD2C2019].[T_REX].Funcionalidad f" +
                " JOIN [GD2C2019].[T_REX].Funcionalidad_Rol fr on fr.id_funcionalidad = f.id_funcionalidad" +
                " JOIN [GD2C2019].[T_REX].Rol r on r.id_rol = fr.id_rol WHERE r.id_rol = @rol");
            cmd.Parameters.Add("@rol",SqlDbType.Int).Value = rol;
            return Database.getData(cmd);
        }


        public DataTable listarDatos()
        {
            SqlCommand cmd = Database.createCommand("SELECT id_rol as Id, nombre as Nombre, estado as Estado FROM [GD2C2019].[T_REX].[Rol]");
            return Database.getData(cmd);
        }

        public DataTable getFuncionalidadesXRol(Rol rol)
        {
            SqlCommand cmd = Database.createCommand("SELECT f.id_funcionalidad as id, f.descripcion as Funcionalidad FROM [GD2C2019].[T_REX].Funcionalidad f" +
                " JOIN [GD2C2019].[T_REX].Funcionalidad_Rol fr on fr.id_funcionalidad = f.id_funcionalidad" +
                " JOIN [GD2C2019].[T_REX].Rol r on r.id_rol = fr.id_rol WHERE r.nombre = @rol");
            cmd.Parameters.Add("@rol", SqlDbType.NVarChar).Value = rol.nombre;
            return Database.getData(cmd);
        }

        public void agregarFuncionalidad(int id, Funcionalidad funcionalidad)
        {
            SqlCommand cmd = Database.createCommand("[T_REX].AgregarFuncionalidadRol");
            cmd.Parameters.Add("@rol_id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@funcionalidad", SqlDbType.Int).Value = funcionalidad.id;
            Database.executeProcedure(cmd);
        }

        public void sacarFuncionalidad(int id, Funcionalidad funcionalidad)
        {
            SqlCommand cmd = Database.createCommand("[T_REX].QuitarFuncionalidadRol");
            cmd.Parameters.Add("@rol_id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@funcionalidad", SqlDbType.Int).Value = funcionalidad.id;
            Database.executeProcedure(cmd);
        }

        public void cambiarNombreRol(int id, String nombre)
        {
            SqlCommand cmd = Database.createCommand("[T_REX].CambiarNombreRol");
            cmd.Parameters.Add("@rol_id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombre;
            Database.executeProcedure(cmd);
        }


        public void borrar_rol(Rol rol)
        {
            SqlCommand cmd = Database.createCommand("[T_REX].InhabilitarRol");
            cmd.Parameters.Add("@rol_id", SqlDbType.Int).Value = rol.id;
        }

        public void activar_rol(Rol rol)
        {
            SqlCommand cmd = Database.createCommand("[T_REX].ActivarRol");
            cmd.Parameters.Add("@rol_id", SqlDbType.Int).Value = rol.id;
        }
    }
}
