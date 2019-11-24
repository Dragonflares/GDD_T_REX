using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.Facturar
{
    public partial class ListadoFacturable : Form
    {
        public ListadoFacturable()
        {
            InitializeComponent();
        }

        private void btn_volver_Click(object sender, EventArgs e)
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

        private void dgv_proveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == dgv_proveedores.Columns["Dar de Baja"].Index)
            {
                new FrbaOfertas.CanjeCupon.ListadoClientes();
            }
        }

    }
}
