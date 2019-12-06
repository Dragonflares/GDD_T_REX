﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaOfertas.CargaCredito
{
    public partial class ListadoClientes : Form
    {
        public CargaCredito form_anterior;

        public ListadoClientes(CargaCredito ant)
        {
            InitializeComponent();
            this.form_anterior = ant;
            loadClientes();
        }

        private void loadClientes()
        {
            string takeclient = "SELECT cli.[id_cliente] as id, cli.[nombre] as Nombre, cli.[apellido] as Apellido " +
                ", cli.[nro_documento] as DNI, cli.[email] as Mail, " +
                "cli.[creditoTotal] as Crédito " +
                "FROM [GD2C2019].[T_REX].[Cliente] cli " +
                "WHERE 1=1";

            if (!String.IsNullOrEmpty(textBox1.Text)) takeclient += " and lower(nombre) like '" + textBox1.Text.ToLower() + "%'";
            if (!String.IsNullOrEmpty(textBox2.Text)) takeclient += " and lower(apellido) like '" + textBox2.Text.ToLower() + "%'";
            if (!String.IsNullOrEmpty(textBox3.Text)) takeclient += " and lower(email) = '" + textBox3.Text + "%'";
            if (!String.IsNullOrEmpty(textBox4.Text)) takeclient += " and nro_documento LIKE '" + textBox4.Text + "%'";

            takeclient += "ORDER BY [id_cliente] ASC";
            SqlCommand takeClients = FrbaOfertas.Utils.Database.createCommand(takeclient);
            DataTable table = Utils.Database.getData(takeClients);
            this.dgv_clientes.DataSource = table;
        }

        private void dgv_clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == dgv_clientes.Columns["Entregar"].Index)
            {
                MessageBox.Show("Cupón entregado con Éxito!", "Entrega realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            loadClientes();
        }
    }
}
