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
            new PantallaPrincipal("Proveedor").Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PrimerLoginProveedor().Show();
        }
    }
}
