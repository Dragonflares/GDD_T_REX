using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.CargaCredito
{
    public partial class ListadoClientes : Form
    {
        public CargaCredito form_anterior;

        public ListadoClientes(CargaCredito ant)
        {
            InitializeComponent();
            this.form_anterior = ant;
        }

        private void dgv_clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == dgv_clientes.Columns["Entregar"].Index)
            {
                MessageBox.Show("Cupón entregado con Éxito!", "Entrega realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
