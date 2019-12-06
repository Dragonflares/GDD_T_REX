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
using FrbaOfertas.Models.Proveedores;

namespace FrbaOfertas.Facturar
{
    public partial class Facturar : Form
    {
        private Usuario user;
        public Proveedor target;
        public Facturar(Usuario admin)
        {
            user = admin;
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListadoFacturable pantalla = new ListadoFacturable();
            pantalla.Owner = this;
            pantalla.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Owner.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.dgv_ofertas.DataSource;
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = dateTimePicker1.Value.AddDays(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Tiene que seleccionar a un proveedor para generar un listado de Ofertas.",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
