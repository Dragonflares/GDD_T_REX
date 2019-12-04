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

namespace FrbaOfertas.Login
{
    public partial class ClienteLogin : Form
    {
        public ClienteLogin()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            showRoles();
            
        }
        private void showRoles()
        {
            SqlCommand obtenerRoles = FrbaOfertas.Utils.Database.createCommand("SELECT r.nombre FROM [GD2C2019].[T_REX].Rol r");
            DataTable tablaFunc = Utils.Database.getData(obtenerRoles);

            foreach (DataRow row in tablaFunc.Rows)
            {
                comboBox1.Items.Add(row["nombre"]);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand login = FrbaOfertas.Utils.Database.createCommand("[GD2C2019].[T_REX].LogearUsuario");
            login.Parameters.AddWithValue("username", textBox1.Text);
            login.Parameters.AddWithValue("password", textBox2.Text);
            login.Parameters.AddWithValue("tipoUsuario", comboBox1.Text);

            try
            {
                FrbaOfertas.Utils.Database.executeProcedure(login);
                //Utils.Database.executeProcedure(login);
                
                PantallaPrincipal pantalla = new PantallaPrincipal(comboBox1.Text, textBox1.Text);
                pantalla.Owner = this;
                pantalla.Show();
                this.Hide();
                
                /*DataTable tablaFunc = Utils.Database.getDataProcedure(login);
                if (!tablaFunc.HasErrors)
                {
                    this.Hide();
                    new PantallaPrincipal(comboBox1.Text, textBox1.Text).Show();
                }
                 */
                
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Debe indicar el rol sobre el que crea el Usuario!", "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(comboBox1.Text == "Proveedor")
            {
                PrimerLoginProveedor login = new PrimerLoginProveedor();
                login.Owner = this;
                login.Show();
                this.Hide();
            }
            else if (comboBox1.Text == "Cliente")
            {
                PrimerLoginCliente login = new PrimerLoginCliente();
                login.Owner = this;
                login.Show();
                this.Hide();
            }
            else
            {
                NuevoUser login = new NuevoUser(comboBox1.Text);
                login.Owner = this;
                login.Show();
                this.Hide();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Administrativo")
            {
                label4.Visible = false;
                label5.Visible = false;
            }
            else
            {
                label4.Visible = true;
                label5.Visible = true;
            }
        }
    }
}
