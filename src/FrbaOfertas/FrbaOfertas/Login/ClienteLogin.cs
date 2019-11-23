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
            new PantallaPrincipal("Cliente", textBox1.Text).Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PrimerLoginCliente().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Owner.Show();
        }
    }
}
