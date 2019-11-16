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
    public partial class CambioPassword : Form
    {
        public CambioPassword()
        {
            InitializeComponent();
            textBox1.PasswordChar = '*';
            textBox2.PasswordChar = '*';
            textBox3.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Usted ha cambiado la contraseña con éxito.", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
