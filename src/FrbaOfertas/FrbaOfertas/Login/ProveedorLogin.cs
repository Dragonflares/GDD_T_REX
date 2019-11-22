using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.Login
{
    public partial class ProveedorLogin : Form
    {
        public ProveedorLogin()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cuit = "";//asignar valor del cuit, que es el username
            if (textBox2.Text == "1234")
            {
                MessageBox.Show("Como es su primer login, será redirigido a una pantalla para cambiar su contraseña.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            new PantallaPrincipal("Proveedor", cuit).Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PrimerLoginProveedor().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Owner.Show();
        }
    }
}
