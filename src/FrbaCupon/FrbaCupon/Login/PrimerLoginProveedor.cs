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
    public partial class PrimerLoginProveedor : Form
    {
        public PrimerLoginProveedor()
        {
            InitializeComponent();
        }

        private void registrarse_Click(object sender, EventArgs e)
        {
            new PantallaPrincipal("PROVEEDOR").Show();
            this.Close();
        }
    }
}
