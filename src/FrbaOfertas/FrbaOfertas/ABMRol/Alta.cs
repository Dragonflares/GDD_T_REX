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
using FrbaOfertas.Models.Funcionalidades;
using FrbaOfertas.Utils;
using FrbaOfertas.Models.Roles;


namespace FrbaOfertas.ABMRol
{
    public partial class Alta : Form
    {
       RolDAO rolDao = new RolDAO();

        public Alta(ABMRol abmrol)
        {
            InitializeComponent();
            var funcionalidades = rolDao.getFuncionalidades();
            foreach (Funcionalidad funcionalidad in funcionalidades)
            {
                Funcionalidades.Items.Add(funcionalidad);
            }
            NombreNuevoRol.KeyPress += noNumber_KeyPress;
        }

        private void noNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NombreNuevoRol.Text == "")
            {
                MessageBox.Show("Debe indicar el nombre del nuevo rol!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Funcionalidades.Text == "")
            {
                MessageBox.Show("Debe indicar la funcionalidad base del nuevo rol!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SqlCommand query = Utils.Database.createCommand("SELECT max (id_rol) FROM [T_REX].ROL");
                    int id = Utils.Database.executeScalar(query) + 1;

                    Rol rol = new Rol(id, NombreNuevoRol.Text);
                    rol.activo = true;

                    Funcionalidad funcionalidad = (Funcionalidad)Funcionalidades.SelectedItem;

                    rolDao.crearRol(rol);
                    rolDao.agregarFuncionalidad(rol.id, funcionalidad);

                    MessageBox.Show("Alta realizada");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
