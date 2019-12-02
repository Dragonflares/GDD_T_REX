using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaOfertas.ABMRol
{
    public partial class Alta : Form
    {
        public Alta(ABMRol abmrol)
        {
            InitializeComponent();
            this.llenarItems(Funcionalidades);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // SqlConnection connection = Utils.Database.getConnection();
                //connection.Open();
                SqlCommand procedure = Utils.Database.createCommand("T_REX.AltaRol");
                procedure.Parameters.Add("@nombre_rol", SqlDbType.NVarChar).Value = NombreNuevoRol.Text;
                procedure.Parameters.Add("@activo", SqlDbType.Bit).Value = 1;
                Utils.Database.executeProcedure(procedure);

                SqlCommand query = Utils.Database.createCommand("SELECT max (id_rol) FROM [T_REX].ROL");
                int id = Utils.Database.executeScalar(query);
                SqlCommand procedure2 = Utils.Database.createCommand("T_REX.AgregarFuncionalidadRol");
                String funcionalidad = Funcionalidades.Text;
                procedure2.Parameters.Add("@nombreNuevaFuncionalidadRol", SqlDbType.VarChar).Value = Funcionalidades.Text;
                procedure2.Parameters.Add("@rol_id", SqlDbType.Int).Value = id;
                Utils.Database.executeProcedure(procedure2);
                // connection.Close();
                MessageBox.Show("Alta realizada");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR",
   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }

        }

        public void llenarItems(ComboBox cb)
        {
            try
            {

                SqlConnection connection = Utils.Database.getConnection();
                connection.Open();
                SqlCommand sql = Utils.Database.createCommand("SELECT descripcion FROM [T_REX].[FUNCIONALIDAD]");
                SqlDataReader sdr = sql.ExecuteReader();
                while (sdr.Read())
                {
                    cb.Items.Add(sdr["descripcion"].ToString());
                }
                cb.SelectedIndex = 0;
                sdr.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se lleno el ComboBox: " + ex.ToString());
            }


        }

        private void NombreNuevoRol_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_atras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
