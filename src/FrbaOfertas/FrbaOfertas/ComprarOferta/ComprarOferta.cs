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
        }

        public void loadOfertas()
        {
            string takeoffer = "SELECT ofer.[id_oferta] as id, ofer.[descripcion] as Descripcion, ofer.[fecha_fin] as [fecha_de_fin], " +
                "ofer.[precio_oferta] as precioOferta, ofer.[precio_lista] as precioLista, ofer.[cantDisponible] as cantdisponible, " +
                "prov.[provee_rs] as proveedor " +
                "FROM [GD2C2019].[T_REX].[Oferta] ofer " +
                "INNER JOIN [GD2C2019].[T_REX].[Proveedor] prov ON prov.id_proveedor = ofer.id_proveedor " +
                "WHERE prov.estado = 1 and ofer.[cantDisponible] > 0";

            if (!String.IsNullOrEmpty(textBox2.Text)) takeoffer += " and lower(descripcion) like '%" + textBox2.Text.ToLower() + "%'";
            if (!String.IsNullOrEmpty(textBox1.Text)) takeoffer += " and prov.provee_rs like '%" + textBox1.Text.ToLower() + "%'";

            takeoffer += "ORDER BY [cod_oferta] ASC";

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
            this.Owner.Show();
            this.Close();
        }
    }
}
