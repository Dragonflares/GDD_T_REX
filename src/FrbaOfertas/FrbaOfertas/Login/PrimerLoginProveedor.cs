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
    public partial class PrimerLoginProveedor : Form
    {
        public PrimerLoginProveedor()
        {
            InitializeComponent();
            contrasenia.PasswordChar = '*';
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
                PantallaPrincipal pantalla = new PantallaPrincipal("Proveedor", nombreUsuario.Text);
                pantalla.Owner = this.Owner;
                pantalla.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tiene que completar todos los campos para registrarse.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Owner.Show();
        }


        // agregar evento de en cambio del texto de nombreUsuario, que haga una busqueda para completar y bloquear los campos de contraseña.
    }
}
