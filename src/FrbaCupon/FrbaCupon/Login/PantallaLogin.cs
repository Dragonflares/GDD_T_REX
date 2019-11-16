using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCupon.Login
{
    public partial class PantallaLogin : Form
    {
        public PantallaLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void admin_Click(object sender, EventArgs e)
        {
            new AdminLogin().Show(this);
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new ProveedorLogin().Show(this);
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ClienteLogin().Show(this);
            this.Hide();
        }
    }
}
