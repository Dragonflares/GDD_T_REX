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
    public partial class ClienteLogin : Form
    {
        public ClienteLogin()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PantallaPrincipal((string)comboBox1.SelectedValue, textBox1.Text).Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedValue == "Proveedor")
            {
                new PrimerLoginProveedor().Show();
                this.Hide();
            }
            else if (comboBox1.SelectedValue == "Cliente")
            {
                new PrimerLoginCliente().Show();
                this.Hide();
            }
            else
            {
                new NuevoUser((string)comboBox1.SelectedValue).Show();
                this.Hide();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Owner.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == "Administrativo")
            {

            }
        }
    }
}
