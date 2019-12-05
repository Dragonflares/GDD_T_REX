﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Models.Usuarios;

namespace FrbaOfertas.CrearOferta
{
    public partial class CrearOferta : Form
    {
        Usuario user;
        public CrearOferta(Usuario usuario)
        {
            InitializeComponent();
            user = usuario;
            if(user.rolActivo.id == 3)
            {
                button1.Visible = false;
                textBox2.Text = user.nombre;
                textBox2.Enabled = false;
            }
            textBox2.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Debe indicar el producto.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Debe indicar un Proveedor.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("La Oferta se ha publicado con éxito.", "Oferta creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrbaOfertas.CrearOferta.ListadoProveedor(this).Show();
        }
    }
}
