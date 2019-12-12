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
using FrbaOfertas.Utils;


namespace FrbaOfertas.Facturar
{
    public partial class Facturar : Form
    {
        public ItemFacturaDAO itemDAO = new ItemFacturaDAO();
        public FacturaDAO factDAO = new FacturaDAO();
        public CompraDAO compDAO = new CompraDAO();
        public OfertaDAO offerDAO = new OfertaDAO();
        private Usuario user;
        public Proveedor target;
        public Facturar(Usuario admin)
        {
            user = admin;
            InitializeComponent();
            textBox1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListadoFacturable pantalla = new ListadoFacturable();
            pantalla.Owner = this;
            pantalla.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
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
                MessageBox.Show("Tiene que seleccionar a un proveedor para poder ver las Ofertas compradas.",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

            }
        }

        public void settarget(Proveedor prov)
        {
            this.target = prov;
            textBox1.Text = prov.razonSocial;
        }
    }
}
