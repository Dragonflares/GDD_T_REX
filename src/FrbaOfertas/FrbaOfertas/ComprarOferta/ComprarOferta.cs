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
using System.Data.SqlClient;
using FrbaOfertas.Models.Ofertas;
using FrbaOfertas.Models.Compras;
using FrbaOfertas.Models.Cupones;


namespace FrbaOfertas.ComprarOferta
{
    public partial class ComprarOferta : Form
    {
        public OfertaDAO ofDAO = new OfertaDAO();
        public CompraDAO compraDAO = new CompraDAO();
        public CuponDAO cupDAO = new CuponDAO();
        public ClienteDAO cliDAO = new ClienteDAO();
        private Usuario user;
        public Cliente target;
        public ComprarOferta(Usuario usuario)
        {
            user = usuario;
            InitializeComponent();
            if (user.rolActivo.id == 2)
            {
                target = user.cliente;
                button1.Visible = false;
                settarget();
            }
            textBox3.Enabled = false;
            loadOfertas();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            loadOfertas();
        }

        public void settarget()
        {
            textBox3.Text = target.nroDocumento.ToString();
            this.text_credito.Text = target.credito.ToString();
        }

        public void loadOfertas()
        {
            string fecha = Database.getDateBeta().ToString("yyyy/MM/dd");
            string takeoffer = "SELECT ofer.[id_oferta] as id, ofer.[descripcion] as Descripcion, ofer.[fecha_fin] as [fecha_de_fin], " +
                "ofer.[precio_oferta] as precioOferta, ofer.[precio_lista] as precioLista, ofer.[cantDisponible] as cantdisponible, " +
                "prov.[provee_rs] as proveedor " +
                "FROM [GD2C2019].[T_REX].[Oferta] ofer " +
                "INNER JOIN [GD2C2019].[T_REX].[Proveedor] prov ON prov.id_proveedor = ofer.id_proveedor " +
                "WHERE prov.estado = 1 and ofer.[cantDisponible] > 0 " +
                " AND ofer.[fecha_inicio] <= '" + fecha + "' AND '" + fecha + "' <= ofer.[fecha_fin]";

            if (!String.IsNullOrEmpty(textBox2.Text)) takeoffer += " and lower(descripcion) like '%" + textBox2.Text.ToLower() + "%'";
            if (!String.IsNullOrEmpty(textBox1.Text)) takeoffer += " and lower(prov.provee_rs) like '%" + textBox1.Text.ToLower() + "%'";

            takeoffer += "ORDER BY ofer.[fecha_fin] ASC";

            SqlCommand takeOffers = FrbaOfertas.Utils.Database.createCommand(takeoffer);
            DataTable table = Utils.Database.getData(takeOffers);
            this.dgv_ofertas.DataSource = table;
        }

        private void dgv_clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == dgv_ofertas.Columns["comprar_prod"].Index)
            {
                if(String.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("Tiene que seleccionar el Cliente a comprar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (numericUpDown1.Value == 0)
                {
                    MessageBox.Show("Tiene que indicar una cantidad a comprar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int id_oferta = int.Parse(dgv_ofertas.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    Oferta oferta = ofDAO.getOferta(id_oferta, true);
                    if (numericUpDown1.Value > oferta.cantDisponible)
                    {
                        MessageBox.Show("No puede indicar una cantidad mayor a la cantidad disponible.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (oferta.cant_max_porCliente == 0)
                    {

                    }
                    else if (target.credito < (oferta.precio_oferta * numericUpDown1.Value))
                    {
                        MessageBox.Show("Usted no dispone de suficiente crédito para realizar esta compra.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (numericUpDown1.Value > oferta.cant_max_porCliente)
                    {
                        MessageBox.Show("Está excediendo el máximo disponible para cada cliente de " + numericUpDown1.Value.ToString()
                            + "!.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (numericUpDown1.Value + compraDAO.cantidadDeOfertasCompradasPorEsteCliente(oferta.id_oferta, target.id)
                        > oferta.cant_max_porCliente)
                    {
                        MessageBox.Show("Está excediendo su máximo disponible de compra para esta oferta de" +
                            (oferta.cant_max_porCliente - compraDAO.cantidadDeOfertasCompradasPorEsteCliente(oferta.id_oferta, target.id)).ToString()
                            + "!.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Compra compra = new Compra();
                    compra.cantidad = (int)numericUpDown1.Value;
                    compra.compra_fecha = Database.getDateBeta();
                    compra.oferta = oferta;
                    compra.cliente = target;

                    compraDAO.guardarCompra(compra);

                    target.credito -= (int)(oferta.precio_oferta * numericUpDown1.Value);
                    oferta.cantDisponible -= (int)numericUpDown1.Value;
                    this.text_credito.Text = target.credito.ToString();
                    this.dgv_ofertas.Rows[e.RowIndex].Cells["cantdisponible"].Value = oferta.cantDisponible;
                    MessageBox.Show("Compra realizada con Éxito!", "Compra realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
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
            loadOfertas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListadoClientes pantalla = new ListadoClientes(this);
            pantalla.Owner = this;
            pantalla.ShowDialog();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComprarOferta_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
