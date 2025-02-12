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
using FrbaOfertas.Models.Proveedores;
using FrbaOfertas.Models.Ofertas;
using FrbaOfertas.Utils;


namespace FrbaOfertas.CrearOferta
{
    public partial class CrearOferta : Form
    {
        public OfertaDAO offerDAO = new OfertaDAO();
        private Usuario user;
        public Proveedor target { get; set; }
        public CrearOferta(Usuario usuario)
        {
            InitializeComponent();
            this.dateTimePicker1.MinDate = Database.getDateBeta();
            num_precio_lista.Maximum = decimal.MaxValue;
            num_precio_oferta.Maximum = num_precio_lista.Value;
            numericUpDown3.Maximum = decimal.MaxValue;
            numericUpDown4.Maximum = numericUpDown3.Value;
            user = usuario;
            if(user.rolActivo.id == 3)
            {
                target = usuario.proveedor;
                button1.Visible = false;
                setTargetName();
                textBox2.Enabled = false;
            }
            textBox2.ReadOnly = true;
        }


        public void setTargetName()
        {
            textBox2.Text = target.razonSocial;
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
            else if (this.dateTimePicker1.Value > this.dateTimePicker2.Value)
            {
                MessageBox.Show("Fecha inicio debe ser menor a Fecha fin.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Oferta oferta = new Oferta();
                oferta.descripcion = textBox1.Text;
                oferta.fecha_inicio = dateTimePicker1.Value;
                oferta.fecha_fin = dateTimePicker2.Value;
                oferta.precio_oferta = num_precio_oferta.Value;
                oferta.precio_lista = num_precio_lista.Value;
                oferta.cantDisponible = (int)numericUpDown3.Value;
                oferta.cant_max_porCliente = (int)numericUpDown4.Value;
                oferta.proveedor = target;

                offerDAO.guardarOferta(null, oferta.descripcion, oferta.fecha_inicio,
                    oferta.fecha_fin, oferta.precio_oferta, oferta.precio_lista,
                    oferta.cantDisponible, oferta.cant_max_porCliente, oferta.proveedor.id);

                MessageBox.Show("La Oferta se ha publicado con éxito.", "Oferta creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new FrbaOfertas.CrearOferta.ListadoProveedor(this).ShowDialog();
        }

        private void CrearOferta_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            this.dateTimePicker2.MinDate = this.dateTimePicker1.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            this.numericUpDown4.Maximum = this.numericUpDown3.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.num_precio_oferta.Maximum = this.num_precio_lista.Value;
        }
    }
}
