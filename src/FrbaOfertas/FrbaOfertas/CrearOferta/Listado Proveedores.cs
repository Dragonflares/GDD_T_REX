using FrbaOfertas.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Models.Proveedores;

namespace FrbaOfertas.CrearOferta
{
    public partial class ListadoProveedor : Form
    {
        public CrearOferta formularioAnterior;
        public ProveedorDAO provDAO = new ProveedorDAO();

        public ListadoProveedor(CrearOferta form)
        {
            formularioAnterior = form;
            InitializeComponent();
            loadRubros();
        }

        private void loadRubros()
        {
            SqlCommand obtenerRubros = FrbaOfertas.Utils.Database.createCommand("SELECT r.nombreDeRubro FROM [GD2C2019].[T_REX].Rubro r");
            DataTable tablaFunc = Utils.Database.getData(obtenerRubros);

            foreach (DataRow row in tablaFunc.Rows)
            {
                comboBox1.Items.Add(row["nombreDeRubro"]);
            }
        }

        private void FormListadoProveedores_Load(object sender, EventArgs e)
        {
            string takeprov = "SELECT p.id_proveedor as id, p.provee_rs as razon_social" +
                ", p.provee_cuit as cuit, r.nombreDeRubro as rubro, p.email as email" +
                " FROM [GD2C2019].[T_REX].[Proveedor] p JOIN [GD2C2019].[T_REX].[Rubro] r ON r.id_rubro = p.id_rubro" +
                " WHERE p.estado = 1";

            if (!String.IsNullOrEmpty(razonsocial.Text)) takeprov += " and lower(p.nombre) like '%" + razonsocial.Text.ToLower() + "%'";
            if (!String.IsNullOrEmpty(comboBox1.Text)) takeprov += " and lower(r.nombreDeRubro) = '%" + comboBox1.Text.ToLower() + "'";
            if (!String.IsNullOrEmpty(textBox1.Text)) takeprov += " and lower(p.cuit) = '%" + textBox1.Text + "%'";
            if (!String.IsNullOrEmpty(textBox5.Text)) takeprov += " and lower(p.email) = '%" + textBox5.Text + "%'";


            takeprov += "ORDER BY [id] ASC";
            SqlCommand takeClients = FrbaOfertas.Utils.Database.createCommand(takeprov);
            DataTable table = Utils.Database.getData(takeClients);
            this.dgv_proveedores.DataSource = table;
        }

        private void loadProveedores()
        {
            string takeprov = "SELECT p.id_proveedor as id, p.provee_rs as razon_social" +
                ", p.provee_cuit as cuit, r.nombreDeRubro as rubro, p.email as email" +
                " FROM [GD2C2019].[T_REX].[Proveedor] p JOIN [GD2C2019].[T_REX].[Rubro] r ON r.id_rubro = p.id_rubro" +
                " WHERE p.estado = 1";

            if (!String.IsNullOrEmpty(razonsocial.Text)) takeprov += " and lower(p.nombre) like '%" + razonsocial.Text.ToLower() + "%'";
            if (!String.IsNullOrEmpty(comboBox1.Text)) takeprov += " and lower(r.nombreDeRubro) = '%" + comboBox1.Text.ToLower() + "'";
            if (!String.IsNullOrEmpty(textBox1.Text)) takeprov += " and lower(p.cuit) = '%" + textBox1.Text + "%'";
            if (!String.IsNullOrEmpty(textBox5.Text)) takeprov += " and lower(p.email) = '%" + textBox5.Text + "%'";


            takeprov += "ORDER BY [id] ASC";
            SqlCommand takeClients = FrbaOfertas.Utils.Database.createCommand(takeprov);
            DataTable table = Utils.Database.getData(takeClients);
            this.dgv_proveedores.DataSource = table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadProveedores();
        }

        private void dgv_proveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == dgv_proveedores.Columns["seleccionar"].Index)
            {
                int id = int.Parse(dgv_proveedores.Rows[e.RowIndex].Cells["id"].Value.ToString());
                
                Proveedor target = provDAO.getProveedor(id);
                this.formularioAnterior.target = target;
                this.formularioAnterior.setTargetName();
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.dgv_proveedores.DataSource;
            if (dt != null)
            {
                dt.Clear();
            }
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
            loadProveedores();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
