using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaOfertas.Utils;


namespace FrbaOfertas.CanjeCupon
{
    public partial class ListadoClientes : Form
    {
        int id_cupon;
        CuponDAO cuponDAO = new CuponDAO();

        public ListadoClientes(int id)
        {
            this.id_cupon = id;
            InitializeComponent();
            loadClientes();
            textBox4.KeyPress += numeric_KeyPress;
        }

        private void numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void loadClientes()
        {
            string takeclient = "SELECT cli.[id_cliente] as id, cli.[nombre] as Nombre, cli.[apellido] as Apellido " +
                ", cli.[nro_documento] as DNI, cli.[email] as Mail, " +
                "cli.[creditoTotal] as Crédito " +
                "FROM [GD2C2019].[T_REX].[Cliente] cli " +
                "WHERE cli.baja_logica = 1 and cli.estado = 1";

            if (!String.IsNullOrEmpty(textBox1.Text)) takeclient += " and lower(cli.nombre) like '%" + textBox1.Text.ToLower() + "%'";
            if (!String.IsNullOrEmpty(textBox2.Text)) takeclient += " and lower(cli.apellido) like '%" + textBox2.Text.ToLower() + "%'";
            if (!String.IsNullOrEmpty(textBox3.Text)) takeclient += " and lower(cli.email) like '%" + textBox3.Text.ToLower() + "%'";
            if (!String.IsNullOrEmpty(textBox4.Text)) takeclient += " and cli.nro_documento like '%" + textBox4.Text + "%'";

            takeclient += "ORDER BY cli.[nombre] ASC";
            SqlCommand takeClients = FrbaOfertas.Utils.Database.createCommand(takeclient);
            DataTable table = Utils.Database.getData(takeClients);
            this.dgv_clientes.DataSource = table;
        }

        private void dgv_clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == dgv_clientes.Columns["Entregar"].Index)
            {
                try
                {
                    int id_cliente = int.Parse(dgv_clientes.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    cuponDAO.entregarCupon(id_cupon, id_cliente);
                    MessageBox.Show("Cupón entregado con Éxito!", "Entrega realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            loadClientes();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.dgv_clientes.DataSource;
            if (dt != null)
                dt.Clear();
            this.Controls.Cast<Control>().ToList()
                .Where(c => c is GroupBox)
                .SelectMany(c => c.Controls.Cast<Control>().ToList())
                .ToList().ForEach(c =>
                {
                    if (c is ComboBox)
                        ((ComboBox)c).SelectedIndex = -1;
                    if (c is TextBox)
                        c.Text = null;
                    if (c is MonthCalendar)
                        ((MonthCalendar)c).Visible = false;
                });
            loadClientes();
        }
    }
}
