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
using FrbaOfertas.Models.Facturas;


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
            text_proveedor.Enabled = false;
            date_desde.Value = Database.getDateBeta(); // No es necesario asignar fecha_hasta ya que se hace en el evento de change.
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListadoFacturable pantalla = new ListadoFacturable(this);
            pantalla.Owner = this;
            pantalla.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            date_hasta.MinDate = date_desde.Value.AddDays(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (text_proveedor.Text == "")
            {
                MessageBox.Show("Tiene que seleccionar a un proveedor para poder ver las Ofertas compradas.",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string takeoffer = "SELECT comp.[id_compra] as id, ofer.[descripcion] as descripcion, comp.[compra_fecha] as [compraFecha], " +
                "ofer.[precio_oferta] as precioOferta, comp.[cantidad] as cantidad, cli.nro_documento as comprador " +
                "FROM [GD2C2019].[T_REX].[Compra] comp " +
                "INNER JOIN [GD2C2019].[T_REX].[Oferta] ofer ON ofer.id_oferta = comp.id_oferta " +
                "INNER JOIN [GD2C2019].[T_REX].[Proveedor] prov ON prov.id_proveedor = ofer.id_proveedor " +
                "INNER JOIN [GD2C2019].[T_REX].[Cliente] cli ON cli.id_cliente = comp.id_cliente " +
                "WHERE prov.id_proveedor = " + target.id +
                " and comp.compra_fecha between '" + date_desde.Text + "' and '" + date_hasta.Text + "'";

                SqlCommand takeOffers = FrbaOfertas.Utils.Database.createCommand(takeoffer);
                DataTable table = Utils.Database.getData(takeOffers);
                this.dgv_ofertas.DataSource = table;
            }
        }

        public void settarget(Proveedor prov)
        {
            this.target = prov;
            text_proveedor.Text = prov.razonSocial;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int? idFactura = this.factDAO.crearFactura(target.id, date_desde.Value, date_hasta.Value);
                if (idFactura == null)
                {
                    MessageBox.Show("Error al generar la factura.",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Factura factura = this.factDAO.getFactura(idFactura);
                factura.proveedor = this.target;
                new InfoFactura(factura).ShowDialog();
                this.btn_limpiar.PerformClick();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Facturar_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
