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
using FrbaOfertas.Models.Proveedores;
using FrbaOfertas.Models.Usuarios;

namespace FrbaOfertas.Utils
{
    public class OfertaDAO
    {
        public Oferta getOferta(int id, bool disponible)
        {
            return this.getOfertas(null, null, id, disponible)[0];
        }


        public Oferta getOfertaXProveedor(string proveedor, bool disponible)
        {
            return this.getOfertas(null, proveedor, null, disponible)[0];
        }

        public List<Oferta> getOfertas(string descripcion, string razon_social, int? idOferta, bool disponible)
        {
            string cmd = "SELECT ofer.[id_oferta], ofer.[cod_oferta], ofer.[descripcion], ofer.[fecha_inicio], ofer.[fecha_fin], ofer.[precio_oferta], " +
                "ofer.[precio_lista], ofer.[cantDisponible], ofer.[cant_max_porCliente], " +
                "prov.[id_proveedor], prov.[provee_rs], prov.[provee_cuit], ru.[id_rubro], ru.[nombreDeRubro], prov.[email], " +
                "prov.[provee_telefono], prov.[estado], u.[id_usuario], u.[username], u.[password]," +
                "d.[id_domicilio], d.[direc_calle], d.[direc_nro_piso], d.[direc_nro_depto], d.[direc_localidad], d.[codigoPostal] " +
                "FROM [GD2C2019].[T_REX].[Oferta] ofer " +
                "INNER JOIN [GD2C2019].[T_REX].[Proveedor] prov ON prov.id_proveedor = ofer.id_proveedor " +
                "INNER JOIN [GD2C2019].[T_REX].[RUBRO] ru ON ru.[id_rubro] = prov.[id_rubro] " +
                "INNER JOIN [GD2C2019].[T_REX].[USUARIO] u ON u.[id_usuario] = prov.[id_usuario] " +
                "INNER JOIN [GD2C2019].[T_REX].[DOMICILIO] d ON d.[id_domicilio] = prov.[id_domicilio] " +
                "WHERE prov.estado = 1";

            if (!String.IsNullOrEmpty(descripcion)) cmd += " and lower(descripcion) like '%" + descripcion.ToLower() + "%'";
            if (!String.IsNullOrEmpty(razon_social)) cmd += " and prov.razon_social like '%" + razon_social.ToLower() + "%'";
            if (idOferta != null) cmd += " and ofer.id_oferta = " + idOferta;
            if (disponible) cmd += " and ofer.cantDisponible > 0";

            cmd += "ORDER BY [cod_oferta] ASC";

            SqlCommand command = FrbaOfertas.Utils.Database.createCommand(cmd);
            DataTable table = Utils.Database.getData(command);

            return table.Rows.Cast<DataRow>().
                Select(row =>
                {
                    return this.createOfertaFromQueryResult(row);
                }).ToList<Oferta>();
        }

        private Oferta createOfertaFromQueryResult(DataRow row)
        {
            Oferta of = new Oferta();
            of.id_oferta = int.Parse(row["id_oferta"].ToString());
            of.cod_oferta = row["cod_oferta"].ToString();
            of.descripcion = row["descripcion"].ToString();
            of.fecha_inicio = DateTime.Parse(row["fecha_inicio"].ToString());
            of.fecha_fin = DateTime.Parse(row["fecha_fin"].ToString());
            of.precio_oferta = Decimal.ToInt32((decimal)row["precio_oferta"]);
            of.precio_lista = Decimal.ToInt32((decimal)row["precio_lista"]);

            of.cantDisponible = int.Parse(row["cantDisponible"].ToString());
            of.cant_max_porCliente = int.Parse(row["cant_max_porCliente"].ToString());
            
            Proveedor juancito = new Proveedor();
            juancito.id = int.Parse(row["id_proveedor"].ToString());
            juancito.razonSocial = row["provee_rs"].ToString();
            juancito.CUIT = row["provee_cuit"].ToString();
            juancito.mail = row["email"].ToString();
            juancito.telefono = int.Parse(row["provee_telefono"].ToString());
            juancito.estado = Boolean.Parse(row["estado"].ToString());

            juancito.usuario = new Usuario(int.Parse(row["id_usuario"].ToString()), row["username"].ToString(), row["password"].ToString());
            juancito.direccion = new Direccion(int.Parse(row["id_domicilio"].ToString()), row["direc_calle"].ToString(), row["direc_nro_piso"].ToString(), row["codigoPostal"].ToString(), row["direc_localidad"].ToString(), row["direc_nro_depto"].ToString());
            juancito.rubro = row["nombreDeRubro"].ToString();

            of.proveedor = juancito;

            return of;
        }

        public void eliminarOferta(int id)
        {
            SqlCommand sp = FrbaOfertas.Utils.Database.createCommand("[GD2C2019].[T_REX].BajaOferta");
            sp.Parameters.AddWithValue("IdOferta", id);
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

        public void guardarOferta(int? id, string descripcion, DateTime fecha_inicio, DateTime fecha_fin,
            int precio_oferta, int precio_lista, int cantDisp, int cantMax, int id_proveedor)
        {
            SqlCommand sp = FrbaOfertas.Utils.Database.createCommand("[GD2C2019].[T_REX].ABMOferta");

            if (id != null)
            {
                sp.Parameters.AddWithValue("IdOferta", id);
                sp.Parameters.AddWithValue("Accion", 'M');
            }
            else
            {
                sp.Parameters.AddWithValue("Accion", 'A');
            }

            sp.Parameters.AddWithValue("Descripcion", descripcion);
            sp.Parameters.AddWithValue("fecha_inicio", fecha_inicio);
            sp.Parameters.AddWithValue("fecha_fin", fecha_fin);
            sp.Parameters.AddWithValue("precio_oferta", precio_oferta);
            sp.Parameters.AddWithValue("precio_lista", precio_lista);
            sp.Parameters.AddWithValue("cantDisp", cantDisp);
            sp.Parameters.AddWithValue("cantMax", cantMax);
            sp.Parameters.AddWithValue("id_proveedor", id_proveedor);


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
