using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using FrbaOfertas.Models.Usuarios;
using FrbaOfertas.Models;
using FrbaOfertas.Models.Proveedores;
using FrbaOfertas.Models.Compras;
using System.Data.SqlTypes;

namespace FrbaOfertas.Utils
{
    public class ProveedorDAO
    {
        public Proveedor getProveedor(int id)
        {
            return this.getProveedors(null, null, null, id)[0];
        }

        public Proveedor getProveedorXUsuario(int id)
        {
            return this.getProveedors(null, null, id, null)[0];
        }

        public List<Proveedor> getProveedors(string razon_social, string cuit, int? idUsuario, int? idProveedor)
        {
            string cmd = "SELECT prov.[id_proveedor], prov.[provee_rs], prov.[provee_cuit], ru.[id_rubro], ru.[nombreDeRubro], prov.[email], " +
                "prov.[provee_telefono], prov.[estado], u.[id_usuario], u.[username], u.[password]," +
                "d.[id_domicilio], d.[direc_calle], d.[direc_nro_piso], d.[direc_nro_depto], d.[direc_localidad], d.[codigoPostal] " +
                "FROM [GD2C2019].[T_REX].[Proveedor] prov " +
                "INNER JOIN [GD2C2019].[T_REX].[RUBRO] ru ON ru.[id_rubro] = prov.[id_rubro] " +
                "INNER JOIN [GD2C2019].[T_REX].[USUARIO] u ON u.[id_usuario] = prov.[id_usuario] " +
                "INNER JOIN [GD2C2019].[T_REX].[DOMICILIO] d ON d.[id_domicilio] = prov.[id_domicilio] " +
                "WHERE prov.estado = 1";

            if (!String.IsNullOrEmpty(razon_social)) cmd += " and lower(provee_rs) like '%" + razon_social.ToLower() + "%'";
            if (!String.IsNullOrEmpty(cuit)) cmd += " and lower(provee_cuit) like '%" + cuit.ToLower() + "%'";
            if (idUsuario != null) cmd += " and u.id_usuario = " + idUsuario;
            if (idProveedor != null) cmd += " and prov.id_proveedor = " + idProveedor;

            cmd += "ORDER BY [provee_rs] ASC";

            SqlCommand command = FrbaOfertas.Utils.Database.createCommand(cmd);
            DataTable table = Utils.Database.getData(command);

            return table.Rows.Cast<DataRow>().
                Select(row =>
                {
                    return this.createProveedorFromQueryResult(row);
                }).ToList<Proveedor>();
        }

        private Proveedor createProveedorFromQueryResult(DataRow row)
        {
            Proveedor prov = new Proveedor();
            prov.id = int.Parse(row["id_proveedor"].ToString());
            prov.razonSocial = row["provee_rs"].ToString();
            prov.CUIT = row["provee_cuit"].ToString();
            prov.mail = row["email"].ToString();
            prov.telefono = int.Parse(row["provee_telefono"].ToString());
            prov.estado = Boolean.Parse(row["estado"].ToString());

            prov.usuario = new Usuario(int.Parse(row["id_usuario"].ToString()), row["username"].ToString(), row["password"].ToString());
            prov.direccion = new Direccion(int.Parse(row["id_domicilio"].ToString()), row["direc_calle"].ToString(), row["direc_nro_piso"].ToString(), row["codigoPostal"].ToString(), row["direc_localidad"].ToString(), row["direc_nro_depto"].ToString());
            prov.rubro = row["nombreDeRubro"].ToString();

            return prov;
        }

        public void eliminarProveedor(int id)
        {
            SqlCommand sp = FrbaOfertas.Utils.Database.createCommand("[GD2C2019].[T_REX].BajaProveedor");
            sp.Parameters.AddWithValue("IdProveedor", id);
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

        public void guardarProveedor(int? id, string razonSocial, string CUIT, string email, int rubro, string telefono, string usuario, string contrasenia, string calle, string piso, string depto, string localidad, string codigoPostal)
        {
            SqlCommand sp = FrbaOfertas.Utils.Database.createCommand("[GD2C2019].[T_REX].AbmProveedor");

            if (id != null)
            {
                sp.Parameters.AddWithValue("IdProveedor", id);
                sp.Parameters.AddWithValue("Accion", 'M');
            }
            else
            {
                sp.Parameters.AddWithValue("Accion", 'A');
            }

            sp.Parameters.AddWithValue("RazonSocial", razonSocial);
            sp.Parameters.AddWithValue("CUIT", CUIT);
            sp.Parameters.AddWithValue("Mail", email);
            sp.Parameters.AddWithValue("Telefono", telefono);
            sp.Parameters.AddWithValue("Rubro", rubro);
            sp.Parameters.AddWithValue("Domicilio", calle);
            sp.Parameters.AddWithValue("NroPiso", piso);
            sp.Parameters.AddWithValue("NroDpto", depto);
            sp.Parameters.AddWithValue("Localidad", localidad);
            sp.Parameters.AddWithValue("CodigoPostal", codigoPostal);
            sp.Parameters.AddWithValue("user", usuario);
            sp.Parameters.AddWithValue("pass", contrasenia);

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
