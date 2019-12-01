﻿using System;
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
    public partial class NuevoUser : Form
    {
        private string rol;
        public NuevoUser(string _rol)
        {
            rol = _rol;
            InitializeComponent();
            textBox1.Text = rol;
            textBox1.Enabled = false;
        }

        private void registrarse_Click(object sender, EventArgs e)
        {
            Boolean estanTodosLlenos = true;
            foreach (Control x in this.Controls)
            {
                if (x is TextBox && x.Text == "")
                {
                    estanTodosLlenos = false;
                    break;
                }
            }
            if (estanTodosLlenos)
            {

                PantallaPrincipal pantalla = new PantallaPrincipal(rol, nombreUsuario.Text);
                pantalla.Owner = this.Owner;
                pantalla.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tiene que completar todos los campos para registrarse.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Owner.Show();
        }
    }
}