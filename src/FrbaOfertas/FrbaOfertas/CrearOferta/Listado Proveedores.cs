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

namespace FrbaOfertas.CrearOferta
{
    public partial class ListadoProveedor : Form
    {
        public CrearOferta formularioAnterior;

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
            SqlCommand cmd = Database.createCommand("SELECT p.id_proveedor as id, p.provee_rs as razon_social" + 
                ", p.provee_cuit as cuit, r.nombreDeRubro as rubro" +
                " FROM [GD2C2019].[T_REX].[Proveedor] p JOIN [GD2C2019].[T_REX].[Rubro] r ON r.id_rubro = p.id_rubro" + 
                " WHERE p.estado = 1");
            dgv_proveedores.DataSource = Database.getData(cmd);
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {

        }

        private void dgv_proveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgv_proveedores.Columns["Seleccionar"].Index)
                {
                    DataGridViewRow row = dgv_proveedores.Rows[e.RowIndex];
                    int id = (int)row.Cells[0].Value;
                    SqlCommand query = FrbaOfertas.Utils.Database.createCommand("SELECT f.descripcion FROM [GD2C2019].[T_REX].Funcionalidad f" + 
                        " JOIN [GD2C2019].[T_REX].Funcionalidad_Rol fr on fr.id_funcionalidad = f.id_funcionalidad" +
                        " JOIN [GD2C2019].[T_REX].Rol r on r.id_rol = fr.id_rol WHERE r.id_rol = @rol");
                    query.Parameters.Add("@rol", SqlDbType.NChar).Value = id;
                }
            }
        }

        private void btn_atras_Click(object sender, EventArgs e)
        {           
            this.Close();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
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
    }
}
