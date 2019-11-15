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
    public partial class PrimerLoginCliente : Form
    {
        public PrimerLoginCliente()
        {
            InitializeComponent();
        }

        private void registrarse_Click(object sender, EventArgs e)
        {
            
            new PantallaPrincipal("CLIENTE").Show();
            this.Close();
        }

    }
}
