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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PantallaPrincipal("Administrativo").Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Owner.Show();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
