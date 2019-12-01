using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.Utils
{
    class Database
    {
        private static String connectionStr = ConfigurationManager.ConnectionStrings["FrbaOfertas"]
            .ConnectionString;
        private static SqlConnection connection = new SqlConnection(connectionStr);

        public static SqlConnection getConnection()
        {
            return connection;
        }

        public static SqlCommand createCommand(String query)
        {
            return new SqlCommand(query, connection);
        }

        public static int execute(SqlCommand command)
        {

            connection.Open();
            int res = 0;
            try
            {
                res = command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }

            return res;
        }

        public static DataTable listarDatos(string consulta)
        {
            connection.Open();
            var tabla = new DataTable();
            try
            {
                using (var adaptador = new SqlDataAdapter(consulta, connection))
                {
                    adaptador.Fill(tabla);
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
                return tabla;
            }
            connection.Close();
            return tabla;
        }

        public static int executeScalar(SqlCommand command)
        {

            connection.Open();
            int res = 0;
            try
            {
                res = (int)command.ExecuteScalar();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
            return res;
        }




        public static String executeString(SqlCommand command)
        {

            connection.Open();
            String res = "";
            try
            {
                res = (String)command.ExecuteScalar();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
            return res;
        }


        public static int executeProcedure(SqlCommand command)
        {
            command.CommandType = CommandType.StoredProcedure;
            return execute(command);
        }

        public static DataTable getData(SqlCommand query)
        {
            DataTable data = new DataTable();

            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query);
                adapter.Fill(data);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return data;
        }

        public static DataTable getDataProcedure(SqlCommand query)
        {
            query.CommandType = CommandType.StoredProcedure;
            return getData(query);
        }

        public static decimal executeScalarDecimal(SqlCommand command)
        {

            connection.Open();
            decimal res = 0;
            try
            {
                res = (decimal)command.ExecuteScalar();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
            return res;
        }


        public static object orDbNull(object o)
        {
            return o != null ? o : DBNull.Value;
        }

        public static object orDbNull(String str)
        {
            return !String.IsNullOrEmpty(str) ? (object)str : DBNull.Value;
        }


        public static List<object> toList(DataTable table)
        {
            return table.Rows.Cast<DataRow>().Select(r => r[0]).ToList();
        }
    }
}
