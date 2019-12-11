using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Models.Usuarios;
using FrbaOfertas.Models.Clientes;
using FrbaOfertas.Utils;


namespace FrbaOfertas.CargaCredito
{
    public partial class CargaCredito : Form
    {
        public ClienteDAO cliDAO = new ClienteDAO();
        public Usuario user;
        public Cliente cliente;
        public CargaCredito(Usuario _user)
        {
            InitializeComponent();
            user = _user;
            textBox1.Enabled = false;
            if (2 == user.rolActivo.id)
            {
                button2.Visible = false;
                setCliente(user.cliente);
            }
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
                cliDAO.modificarCredito(cliente.id, (int)numericUpDown1.Value); 
                MessageBox.Show("Carga acreditada con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Owner.Show();
                this.Close();
            }
        }

        private void CargaCredito_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ListadoClientes(this).ShowDialog();
            
        }

        public void setCliente(Cliente cli)
        {
            this.cliente = cli;
            textBox1.Text = cliente.nroDocumento.ToString();
        }
    }
}
