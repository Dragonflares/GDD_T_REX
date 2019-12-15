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
            date_hasta.MinDate = date_desde.Value;
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
                "ofer.[precio_oferta] as precioOferta, cli.nro_documento as comprador " +
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
            Factura factura = new Factura();
            SqlCommand query1 = Utils.Database.createCommand("SELECT max (id_factura) FROM [T_REX].Factura_Proveedor");
            factura.id_factura = Utils.Database.executeScalar(query1) + 1;
            SqlCommand query2 = Utils.Database.createCommand("SELECT max(cast((nro_factura) as int)) FROM [T_REX].Factura_Proveedor");
            factura.nro_factura = Utils.Database.executeScalar(query2) + 1;
            factura.tipo_fact = "B";
            factura.proveedor = target;
            factura.fecha_inicio = date_desde.Value;
            factura.fecha_fin = date_hasta.Value;
            string check = date_desde.Text;
            string takeMoney = "SELECT cast(SUM(cup.cupon_precio_oferta) as int) FROM [GD2C2019].[T_REX].[CUPON] cup " +
                "INNER JOIN [GD2C2019].[T_REX].[Compra] comp ON comp.id_compra = cup.id_compra " +
                "INNER JOIN [GD2C2019].[T_REX].[Oferta] ofer ON ofer.id_oferta = comp.id_oferta " +
                "INNER JOIN [GD2C2019].[T_REX].[Proveedor] prov ON prov.id_proveedor = ofer.id_proveedor  " +
                "WHERE prov.id_proveedor = " + target.id +
                " and comp.compra_fecha between '" + date_desde.Text + "' and '" + date_hasta.Text + "'";

            SqlCommand takeMaCash = Database.createCommand(takeMoney);
            factura.importe_fact = Database.executeScalar(takeMaCash);
            List<int> idsOferta = obtenerIdsOfertas();

            foreach (int id in idsOferta)
            {
                ItemFactura itemFactura = new ItemFactura();
                itemFactura.factura = factura;
                itemFactura.oferta = offerDAO.getOferta(id, false);
                itemFactura.cantidad = compDAO.cantidadDeUnaOfertaCompradasEnPeriodo(date_desde.Value,
                    date_hasta.Value, itemFactura.oferta.id_oferta);
                itemFactura.importe_oferta = compDAO.recaudacionTotalOfertaEnPeriodo(date_desde.Value,
                    date_hasta.Value, itemFactura.oferta);
                itemDAO.crearItemFactura(itemFactura);
            }
            factDAO.crearFactura(factura);
            new InfoFactura(factura).ShowDialog();
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

        private List<int> obtenerIdsOfertas()
        {       
            string cmd = "SELECT DISTINCT(offer.id_oferta) FROM [GD2C2019].[T_REX].OFERTA offer " +
                "JOIN [GD2C2019].[T_REX].COMPRA comp ON comp.id_oferta = offer.id_oferta " +
                "WHERE offer.id_proveedor = " + target.id +
                " AND comp.compra_fecha BETWEEN '" + date_desde.Text + "' AND '" + date_hasta.Text + "'" +
                " ORDER BY offer.id_oferta";

            SqlCommand command = FrbaOfertas.Utils.Database.createCommand(cmd);
            DataTable table = Utils.Database.getData(command);

            return table.Rows.Cast<DataRow>().
                Select(row =>
                {
                    return int.Parse(row["id_oferta"].ToString());
                }).ToList<int>();
        }

        private void Facturar_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
