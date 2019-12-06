using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Models.Usuarios;
using FrbaOfertas.Models.Roles;
using FrbaOfertas.Utils;
using FrbaOfertas.Models.Clientes;

namespace FrbaOfertas.ComprarOferta
{
    public partial class ComprarOferta : Form
    {
        private Usuario user;
        public Cliente target;
        public ComprarOferta(Usuario usuario)
        {
            user = usuario;
            InitializeComponent();
            if (user.rolActivo.id == 2)
            {
                button1.Visible = false;
                textBox3.Text = user.cliente.nroDocumento.ToString();
            }
            button1.Enabled = false;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {

        }

        private void dgv_clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == dgv_clientes.Columns["Comprar"].Index)
            {
                if (numericUpDown1.Value == 0)
                {
                    MessageBox.Show("Tiene que indicar una cantidad a comprar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Compra realizada con Éxito!", "Compra realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListadoClientes pantalla = new ListadoClientes(this);
            pantalla.Owner = this;
            pantalla.ShowDialog();
        }
    }
}
