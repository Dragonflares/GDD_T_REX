using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Utils;
using FrbaOfertas.Models.Clientes;
using System.Data.SqlClient;

namespace FrbaOfertas.ABMCliente
{
    public partial class ListadoCliente : Form
    {
        ClienteDAO clienteDao = new ClienteDAO();
        public ListadoCliente()
        {
            InitializeComponent();
            textBox4.KeyPress += numeric_KeyPress;
        }

        private void numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void ListadoCliente_Load(object sender, EventArgs e)
        {
            this.cargarClientes();
        }

        private void cargarClientes()
        {
            string cmd = "SELECT cli.[id_cliente] as id, cli.[nombre] as nombres, cli.[apellido] as apellido, cli.[nro_documento] as nroDocumento" + 
                ", cli.[tipo_documento] as tipoDocumento, cli.[fechaDeNacimiento] as fechaNacimiento, cli.[email] as mail, " +
                "cli.[telefono] as telefono, cli.[baja_logica] as estado , cli.[creditoTotal] as credito, " +
                "d.[direc_calle] as direccion " +
                "FROM [GD2C2019].[T_REX].[Cliente] cli " +
                "INNER JOIN [GD2C2019].[T_REX].[USUARIO] u ON u.[id_usuario] = cli.[id_usuario] " +
                "INNER JOIN [GD2C2019].[T_REX].[DOMICILIO] d ON d.[id_domicilio] = cli.[id_domicilio] " +
                "WHERE 1=1";

            if (!String.IsNullOrEmpty(nombre_text.Text)) cmd += " and lower(nombre) like '%" + nombre_text.Text.ToLower() + "%'";
            if (!String.IsNullOrEmpty(apellido_text.Text)) cmd += " and lower(apellido) like '%" + apellido_text.Text.ToLower() + "%'";
            if (!String.IsNullOrEmpty(textBox3.Text)) cmd += " and lower(email) = '" + textBox3.Text + "%'";
            if (!String.IsNullOrEmpty(textBox4.Text)) cmd += " and nro_documento = '" + textBox4.Text + "'";

            cmd += "ORDER BY cli.[id_cliente] ASC";

            SqlCommand command = FrbaOfertas.Utils.Database.createCommand(cmd);

            this.tablaClientes.DataSource = Utils.Database.getData(command); 
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            string cmd = "SELECT cli.[id_cliente] as id, cli.[nombre] as nombres, cli.[apellido] as apellido, cli.[nro_documento] as nroDocumento" +
                ", cli.[tipo_documento] as tipoDocumento, cli.[fechaDeNacimiento] as fechaNacimiento, cli.[email] as mail, " +
                "cli.[telefono] as telefono, cli.[baja_logica] as estado , cli.[creditoTotal] as credito, " +
                "d.[direc_calle] as direccion " +
                "FROM [GD2C2019].[T_REX].[Cliente] cli " +
                "INNER JOIN [GD2C2019].[T_REX].[USUARIO] u ON u.[id_usuario] = cli.[id_usuario] " +
                "INNER JOIN [GD2C2019].[T_REX].[DOMICILIO] d ON d.[id_domicilio] = cli.[id_domicilio] " +
                "WHERE 1=1";

            if (!String.IsNullOrEmpty(nombre_text.Text)) cmd += " and lower(nombre) like '%" + nombre_text.Text.ToLower() + "%'";
            if (!String.IsNullOrEmpty(apellido_text.Text)) cmd += " and lower(apellido) like '%" + apellido_text.Text.ToLower() + "%'";
            if (!String.IsNullOrEmpty(textBox3.Text)) cmd += " and lower(email) = '" + textBox3.Text + "%'";
            if (!String.IsNullOrEmpty(textBox4.Text)) cmd += " and nro_documento = '" + textBox4.Text + "'";

            cmd += "ORDER BY cli.[id_cliente] ASC";

            SqlCommand command = FrbaOfertas.Utils.Database.createCommand(cmd);

            this.tablaClientes.DataSource = Utils.Database.getData(command); 
        }

        private void btn_baja_Click(object sender, EventArgs e)
        {
            if (this.tablaClientes.SelectedRows.Count > 0)
            {
                try 
                {

                    int id = (Int32)this.tablaClientes.SelectedRows[0].Cells[0].Value;
                    this.clienteDao.eliminarCliente(id);
                    this.cargarClientes();

                }
                catch (SqlException exception)
                {
                    MessageBox.Show(exception.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione Un Cliente");
            }
        }

        private void btn_alta_Click(object sender, EventArgs e)
        {
            AltaCliente altaClienteForm = new AltaCliente();
            altaClienteForm.ShowDialog();
            this.cargarClientes();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (this.tablaClientes.SelectedRows.Count > 0)
            {
                int id = (Int32)this.tablaClientes.SelectedRows[0].Cells[0].Value;
                Cliente cliente = this.clienteDao.getCliente(id);
                AltaCliente altaClienteForm = new AltaCliente(cliente);
                altaClienteForm.ShowDialog();
                this.cargarClientes();
            }
            else
            {
                MessageBox.Show("Seleccione Un Cliente");
            }
        }

        private void ListadoCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
