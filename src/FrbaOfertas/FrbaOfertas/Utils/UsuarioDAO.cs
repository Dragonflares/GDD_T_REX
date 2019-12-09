using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaOfertas.Models.Clientes;
using System.Data;
using System.Data.SqlClient;
using FrbaOfertas.Models.Usuarios;
using FrbaOfertas.Models;

namespace FrbaOfertas.Utils
{
    class UsuarioDAO
    {
        public Usuario getUsuario(string username)
        {
            string cmd = "SELECT u.[id_usuario], u.[username], u.[password]" +
                " FROM [GD2C2019].[T_REX].[Usuario] u" +
                " WHERE u.username = '" + username + "'";

            SqlCommand command = FrbaOfertas.Utils.Database.createCommand(cmd);
            DataTable table = Utils.Database.getData(command);

            return table.Rows.Cast<DataRow>().
                Select(row =>
                {
                    return this.createUsuarioFromQueryResult(row);
                }).ToList<Usuario>()[0];
        }

        public Usuario getUsuarioById(int id)
        {
            string cmd = "SELECT u.[id_usuario], u.[username], u.[password]" +
                " FROM [GD2C2019].[T_REX].[Usuario] u" +
                " WHERE u.id_usuario =" + id;

            SqlCommand command = FrbaOfertas.Utils.Database.createCommand(cmd);
            DataTable table = Utils.Database.getData(command);

            return table.Rows.Cast<DataRow>().
                Select(row =>
                {
                    return this.createUsuarioFromQueryResult(row);
                }).ToList<Usuario>()[0];
        }

        private Usuario createUsuarioFromQueryResult(DataRow row)
        {
            Usuario user = new Usuario(int.Parse(row["id_usuario"].ToString()),
                row["username"].ToString(),
                row["password"].ToString());
            return user;
        }

        public void eliminarUsuario(int id)
        {
            SqlCommand sp = FrbaOfertas.Utils.Database.createCommand("[GD2C2019].[T_REX].BajaUsuario");
            sp.Parameters.AddWithValue("IdUsuario", id);
            //sp.Parameters.AddWithValue("Accion", 'B');

            SqlParameter text = new SqlParameter("@out", SqlDbType.VarChar, 1000);
            text.Direction = ParameterDirection.Output;
            sp.Parameters.Add(text);

            FrbaOfertas.Utils.Database.executeProcedure(sp);

            if (!String.IsNullOrEmpty(text.Value.ToString()))
            {
                throw new Exception(text.Value.ToString());
            }

        }

        public void guardarUsuario(int? id, string nombre, string pass)
        {
            SqlCommand sp = FrbaOfertas.Utils.Database.createCommand("[GD2C2019].[T_REX].AltaUsuario");

            if (id != null)
            {
                sp.Parameters.AddWithValue("IdUsuario", id);
                sp.Parameters.AddWithValue("Accion", 'M');
            }
            else
            {
                sp.Parameters.AddWithValue("Accion", 'A');
            }

            sp.Parameters.AddWithValue("Nombre", nombre);
            sp.Parameters.AddWithValue("Password", pass);

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
