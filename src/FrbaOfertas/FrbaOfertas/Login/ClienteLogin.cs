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

namespace FrbaOfertas.Login
{
    public partial class ClienteLogin : Form
    {
        public ClienteLogin()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            showRoles();
        }
        private void showRoles()
        {
            SqlCommand obtenerRoles = FrbaOfertas.Utils.Database.createCommand("SELECT r.nombre FROM [GD2C2019].[T_REX].Rol r");
            DataTable tablaFunc = Utils.Database.getData(obtenerRoles);

            foreach (DataRow row in tablaFunc.Rows)
            {
                comboBox1.Items.Add(row["nombre"]);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new PantallaPrincipal(comboBox1.Text, textBox1.Text).Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Proveedor")
            {
                new PrimerLoginProveedor().Show();
                this.Hide();
            }
            else if (comboBox1.Text == "Cliente")
            {
                new PrimerLoginCliente().Show();
                this.Hide();
            }
            else
            {
                new NuevoUser(comboBox1.Text).Show();
                this.Hide();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Owner.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Administrativo")
            {
                label4.Visible = false;
                label5.Visible = false;
            }
            else
            {
                label4.Visible = true;
                label5.Visible = true;
            }
        }
    }
}
