using FrbaOfertas.Models.Proveedores;
using FrbaOfertas.Models.Rubros;
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

namespace FrbaOfertas.ABMProveedor
{
    public partial class ABMProveedor : Form
    {
        RubroDAO rubroDao = new RubroDAO();
        ProveedorDAO proveedorDao = new ProveedorDAO();

        public ABMProveedor()
        {
            InitializeComponent();
        }

        private void ABMProveedor_Load(object sender, EventArgs e)
        {
            this.cargarRubros();
            this.cargarProveedores();
        }

        private void cargarProveedores()
        {
            this.tabla_proveedores.DataSource = this.proveedorDao.getProveedores(this.text_razonsocial.Text, this.text_cuit.Text, this.text_email.Text, this.combo_rubros.Text, null, null, null);
        }

        private void cargarRubros()
        {
            List<Rubro> rubros = this.rubroDao.getRubros();
            foreach (Rubro rubro in rubros)
            {
                this.combo_rubros.Items.Add(rubro.nombre);
            }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
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

            this.cargarProveedores();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            this.cargarProveedores();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMProveedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void btn_baja_Click(object sender, EventArgs e)
        {
            if (this.tabla_proveedores.SelectedRows.Count > 0)
            {
                try
                {

                    int id = (Int32)this.tabla_proveedores.SelectedRows[0].Cells["Id"].Value;

                    if ((Boolean) this.tabla_proveedores.SelectedRows[0].Cells["Habilitado"].Value)
                    {
                        this.proveedorDao.deshabilitarProveedor(id);
                        this.tabla_proveedores.SelectedRows[0].Cells["Habilitado"].Value = false;
                        this.btn_baja.Text = "Habilitar";
                    }
                    else
                    {
                        this.proveedorDao.habilitarProveedor(id);
                        this.tabla_proveedores.SelectedRows[0].Cells["Habilitado"].Value = true;
                        this.btn_baja.Text = "Deshabilitar";
                    }
                }
                catch (SqlException exception)
                {
                    MessageBox.Show(exception.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione Un Proveedor");
            }
        }

        private void tabla_proveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (this.tabla_proveedores.SelectedRows.Count > 0)
            {
                if ((Boolean)this.tabla_proveedores.SelectedRows[0].Cells["Habilitado"].Value)
                {
                    this.btn_baja.Text = "Deshabilitar";
                }
                else
                {
                    this.btn_baja.Text = "Habilitar";
                }
            }
        }

        private void btn_alta_Click(object sender, EventArgs e)
        {
            AltaProveedor altaProveedorForm = new AltaProveedor();
            altaProveedorForm.ShowDialog();
            this.cargarProveedores();
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (this.tabla_proveedores.SelectedRows.Count > 0)
            {
                int id = (Int32)this.tabla_proveedores.SelectedRows[0].Cells["Id"].Value;
                Proveedor proveedor = this.proveedorDao.getProveedor(id);
                AltaProveedor altaProveedorForm = new AltaProveedor(proveedor);
                altaProveedorForm.ShowDialog();
                this.cargarProveedores();
            }
            else
            {
                MessageBox.Show("Seleccione Un Cliente");
            }
        }

    }
}
