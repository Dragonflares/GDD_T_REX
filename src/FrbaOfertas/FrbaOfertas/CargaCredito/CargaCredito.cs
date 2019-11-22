using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.CargaCredito
{
    public partial class CargaCredito : Form
    {
        public CargaCredito()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Debe seleccionar un metodo de pago!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Debe indicar el DNI del titular de la tarjeta!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox8.Text == "")
            {
                MessageBox.Show("Debe indicar el banco de la tarjeta!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Debe indicar le numero de tarjeta!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox2.Text == "")
            {
                MessageBox.Show("Debe indicar un tipo de tarjeta!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (numericUpDown1.Value < 1)
            {
                MessageBox.Show("No puede realizar una carga nula o negativa!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                //#TODO agregar funcionalidad para que impacte cambios en base de datos(no hace falta realizar verificaciones)
                MessageBox.Show("Carga acreditada con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Owner.Show();
                this.Close();
            }
        }
    }
}
