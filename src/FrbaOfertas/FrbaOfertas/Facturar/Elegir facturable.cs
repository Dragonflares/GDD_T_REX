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
using FrbaOfertas.Utils;
using FrbaOfertas.Models.Rubros;

namespace FrbaOfertas.Facturar
{
    public partial class ListadoFacturable : Form
    {
        public ProveedorDAO provDAO = new ProveedorDAO();
        private RubroDAO rubroDAO = new RubroDAO();
        private Facturar formularioAnterior;
        public ListadoFacturable(Facturar form)
        {
            formularioAnterior = form;
            InitializeComponent();
            loadRubros();
            loadProveedores();
            text_cuit.KeyPress += cuit_KeyPress;
        }

        private void loadRubros()
        {
            List<Rubro> rubros = this.rubroDAO.getRubros();
            this.combo_rubro.Items.Add("");
            foreach (Rubro rubro in rubros)
            {
                this.combo_rubro.Items.Add(rubro.nombre);
            }
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Close();
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
                this.formularioAnterior.settarget(target);
                this.Close();
            }
        }

        private void loadProveedores()
        {
            string takeprov = "SELECT p.id_proveedor as id, p.provee_rs as razon_social" +
                ", p.provee_cuit as cuit, r.nombreDeRubro as rubro, p.email as email" +
                " FROM [GD2C2019].[T_REX].[Proveedor] p JOIN [GD2C2019].[T_REX].[Rubro] r ON r.id_rubro = p.id_rubro" +
                " WHERE p.estado = 1";

            if (!String.IsNullOrEmpty(text_razonsocial.Text)) takeprov += " and lower(p.provee_rs) like '%" + text_razonsocial.Text.ToLower() + "%'";
            if (!String.IsNullOrEmpty(combo_rubro.Text)) takeprov += " and lower(r.nombreDeRubro) like '%" + combo_rubro.Text.ToLower() + "'";
            if (!String.IsNullOrEmpty(text_cuit.Text)) takeprov += " and lower(p.provee_cuit) like '%" + text_cuit.Text.ToLower() + "%'";
            if (!String.IsNullOrEmpty(text_email.Text)) takeprov += " and lower(p.email) like '%" + text_email.Text.ToLower() + "%'";


            takeprov += "ORDER BY [razon_social] ASC";
            SqlCommand takeClients = FrbaOfertas.Utils.Database.createCommand(takeprov);
            DataTable table = Utils.Database.getData(takeClients);
            this.dgv_proveedores.DataSource = table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.dgv_proveedores.DataSource;
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

        private void button2_Click(object sender, EventArgs e)
        {
            loadProveedores();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '-')) || ((hasTwo((sender as TextBox).Text) && char.IsDigit(text_cuit.Text.Last()))))
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                    e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) && (cantNumeros(text_cuit.Text) == 2) && ((sender as TextBox).Text.IndexOf('-') < 0))
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) && (cantNumeros(text_cuit.Text) == 10) && !(hasTwo((sender as TextBox).Text)))
            {
                e.Handled = true;
            }
            else if ((e.KeyChar == '-') && (hasTwo((sender as TextBox).Text) || (((sender as TextBox).Text.IndexOf('-') == ((sender as TextBox).Text.Length - 1)))))
            {
                e.Handled = true;
            }
        }

        public int cantNumeros(string lecturer)
        {
            int counter = 0;
            foreach (char letter in lecturer)
            {
                if (char.IsDigit(letter))
                {
                    counter++;
                }
            }
            return counter;
        }

        public Boolean hasTwo(string lecturer)
        {
            int counter = 0;
            foreach (char letter in lecturer)
            {
                if (letter == '-')
                {
                    counter++;
                }
            }
            if (counter > 1)
            {
                return true;
            }
            else
                return false;
        }

    }
}
