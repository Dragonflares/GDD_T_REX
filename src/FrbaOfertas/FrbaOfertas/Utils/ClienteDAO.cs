﻿using System;
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
    public class ClienteDAO
    {
        public Cliente getCliente(int id)
        {
            return this.getClientes(null, null, null, id)[0];
        }

        public Cliente getClienteXUsuario(int id)
        {
            return this.getClientes(null, null, id, null)[0];
        }

        public List<Cliente> getClientes(string nombre, string apellido, int? idUsuario, int? idCliente) 
        {
            string cmd = "SELECT cli.[id_cliente], cli.[nombre], cli.[apellido], cli.[nro_documento], cli.[tipo_documento], cli.[fechaDeNacimiento], cli.[email], " +
                "cli.[telefono], cli.[baja_logica], cli.[creditoTotal], u.[id_usuario], u.[username], u.[password]," +
                "d.[id_domicilio], d.[direc_calle], d.[direc_nro_piso], d.[direc_nro_depto], d.[direc_localidad], d.[codigoPostal] " +
                "FROM [GD2C2019].[T_REX].[Cliente] cli " +
                "INNER JOIN [GD2C2019].[T_REX].[USUARIO] u ON u.[id_usuario] = cli.[id_usuario] " +
                "INNER JOIN [GD2C2019].[T_REX].[DOMICILIO] d ON d.[id_domicilio] = cli.[id_domicilio] " +
                "WHERE 1=1";

            if (!String.IsNullOrEmpty(nombre)) cmd += " and lower(nombre) like '%" + nombre.ToLower() + "%'";
            if (!String.IsNullOrEmpty(apellido)) cmd += " and lower(apellido) like '%" + apellido.ToLower() + "%'";
            if (idUsuario != null) cmd += " and u.id_usuario = " + idUsuario;
            if (idCliente != null) cmd += " and cli.id_cliente = " + idCliente;

            cmd += "ORDER BY [nombre] ASC";

            SqlCommand command = FrbaOfertas.Utils.Database.createCommand(cmd);
            DataTable table = Utils.Database.getData(command);

            return table.Rows.Cast<DataRow>().
                Select(row => { 
                    return this.createClienteFromQueryResult(row);
                }).ToList<Cliente>();
        }

        private Cliente createClienteFromQueryResult(DataRow row) {
            Cliente cli = new Cliente();
            cli.id = int.Parse(row["id_cliente"].ToString());
            cli.nombres = row["nombre"].ToString();
            cli.apellido = row["apellido"].ToString();
            cli.nroDocumento = int.Parse(row["nro_documento"].ToString());
            cli.tipoDocumento = row["tipo_documento"].ToString();
            cli.fechaNacimiento = DateTime.Parse(row["fechaDeNacimiento"].ToString());
            cli.mail = row["email"].ToString();
            cli.telefono = int.Parse(row["telefono"].ToString());
            cli.estado = Boolean.Parse(row["baja_logica"].ToString());
            cli.credito = long.Parse(row["creditoTotal"].ToString());

            cli.usuario = new Usuario(int.Parse(row["id_usuario"].ToString()), row["username"].ToString(), row["password"].ToString());
            cli.direccion = new Direccion(int.Parse(row["id_domicilio"].ToString()), row["direc_calle"].ToString(), row["direc_nro_piso"].ToString(), row["codigoPostal"].ToString(), row["direc_localidad"].ToString(), row["direc_nro_depto"].ToString());

            return cli;
        }

        public void deshabilitarCliente(int id)
        {
            SqlCommand sp = FrbaOfertas.Utils.Database.createCommand("[GD2C2019].[T_REX].DeshabilitarCliente");
            sp.Parameters.AddWithValue("IdCliente", id);
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

        public void habilitarCliente(int id)
        {
            SqlCommand sp = FrbaOfertas.Utils.Database.createCommand("[GD2C2019].[T_REX].HabilitarCliente");
            sp.Parameters.AddWithValue("IdCliente", id);
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

        public void guardarCliente(int? id, string nombre, string apellido, string tipoDni, int nroDni, DateTime fechaNac, string email, int telefono, string usuario, string contrasenia, string calle, string piso, string depto, string localidad, string codigoPostal) 
        {
            SqlCommand sp = FrbaOfertas.Utils.Database.createCommand("[GD2C2019].[T_REX].AbmUsuario");

            if(id != null) 
            {
                sp.Parameters.AddWithValue("IdCliente", id);
                sp.Parameters.AddWithValue("Accion", 'M');
            }
            else
            {
                sp.Parameters.AddWithValue("Accion", 'A');
            }

            sp.Parameters.AddWithValue("Nombre", nombre);
            sp.Parameters.AddWithValue("Apellido", apellido);
            sp.Parameters.AddWithValue("TipoDocumento", tipoDni);
            sp.Parameters.AddWithValue("Documento", nroDni);
            sp.Parameters.AddWithValue("FechaNacimiento", fechaNac);
            sp.Parameters.AddWithValue("Mail", email);
            sp.Parameters.AddWithValue("Telefono", telefono);
            sp.Parameters.AddWithValue("Domicilio", calle);
            sp.Parameters.AddWithValue("NroPiso", piso);
            sp.Parameters.AddWithValue("NroDpto", depto);
            sp.Parameters.AddWithValue("Localidad", localidad);
            sp.Parameters.AddWithValue("CodigoPostal", codigoPostal);
            sp.Parameters.AddWithValue("user", usuario);
            sp.Parameters.AddWithValue("pass", contrasenia); // Puede ser NULL en caso de modificacion.
            
            SqlParameter text = new SqlParameter("@out", SqlDbType.VarChar, 1000);
            text.Direction = ParameterDirection.Output;
            sp.Parameters.Add(text);

            FrbaOfertas.Utils.Database.executeProcedure(sp);

            if (!String.IsNullOrEmpty(text.Value.ToString()))
            {
                throw new Exception(text.Value.ToString());
            }
        }

        public void cargarCredito(int id_cliente, int monto, DateTime fecha_credito, string forma_pago, string tipo_tarjeta, string nro_tarjeta, string titular_tarjeta, string banco_tarjeta)
        {
            SqlCommand sp = FrbaOfertas.Utils.Database.createCommand("[GD2C2019].[T_REX].CargarSaldo");

            sp.Parameters.AddWithValue("IdCliente", id_cliente);
            sp.Parameters.AddWithValue("Monto", monto);
            sp.Parameters.AddWithValue("fecha_credito", fecha_credito);
            sp.Parameters.AddWithValue("forma_pago", forma_pago);
            sp.Parameters.AddWithValue("tipo_tarjeta", tipo_tarjeta);
            sp.Parameters.AddWithValue("nro_tarjeta", nro_tarjeta);
            sp.Parameters.AddWithValue("titular_tarjeta", titular_tarjeta);
            sp.Parameters.AddWithValue("banco_tarjeta", banco_tarjeta);

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
