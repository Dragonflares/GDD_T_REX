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
        }

        private void ListadoCliente_Load(object sender, EventArgs e)
        {
            this.cargarClientes();
        }

        private void cargarClientes()
        {
            this.tablaClientes.DataSource = this.clienteDao.getClientes(this.nombre_text.Text, this.apellido_text.Text);
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            this.tablaClientes.DataSource = this.clienteDao.getClientes(this.nombre_text.Text, this.apellido_text.Text);
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
    }
}
