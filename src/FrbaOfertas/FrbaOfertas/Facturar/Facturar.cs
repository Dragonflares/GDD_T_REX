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
using System.Data.SqlClient;

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
            ListadoFacturable pantalla = new ListadoFacturable(this);
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
                string takeoffer = "SELECT comp.[id_compra] as id, ofer.[descripcion] as descripcion, comp.[compra_fecha] as [compraFecha], " +
                "ofer.[precio_oferta] as precioOferta, cli.nro_documento as comprador " +
                "FROM [GD2C2019].[T_REX].[Compra] comp " +
                "INNER JOIN [GD2C2019].[T_REX].[Oferta] ofer ON ofer.id_oferta = comp.id_oferta " +
                "INNER JOIN [GD2C2019].[T_REX].[Proveedor] prov ON prov.id_proveedor = ofer.id_proveedor " +
                "INNER JOIN [GD2C2019].[T_REX].[Cliente] cli ON cli.id_cliente = comp.id_cliente " +
                "WHERE prov.id_proveedor = " + target.id +
                " and comp.compra_fecha between '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";

                SqlCommand takeOffers = FrbaOfertas.Utils.Database.createCommand(takeoffer);
                DataTable table = Utils.Database.getData(takeOffers);
                this.dgv_ofertas.DataSource = table;
            }
        }

        public void settarget(Proveedor prov)
        {
            this.target = prov;
            textBox1.Text = prov.razonSocial;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
