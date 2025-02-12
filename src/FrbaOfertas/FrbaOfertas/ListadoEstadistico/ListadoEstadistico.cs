﻿using FrbaOfertas.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Models.Usuarios;

namespace FrbaOfertas.ListadoEstadistico
{
    public partial class ListadoEstadistico : Form
    {
        private Usuario admin;
        public ListadoEstadistico(Usuario admin)
        {
            InitializeComponent();
            anio.KeyPress += numeric_KeyPress;
            this.anio.MaxLength = 4;
        }

        private void numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void semestre_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buscarButton_Click(object sender, EventArgs e)
        {

            gridResultados.Columns.Clear();
            Boolean estanTodosLlenos = !String.IsNullOrEmpty(this.tipoListado.Text) && !String.IsNullOrEmpty(this.anio.Text) && this.anio.Text.Length == 4 && !String.IsNullOrEmpty(this.semestre.Text);
            /*
            foreach (Control x in this.Controls)
            {
                if (x is TextBox && x.Text == "")
                {
                    estanTodosLlenos = false;
                    break;
                }
                else if (x is ComboBox && x.Text == "")
                {
                    estanTodosLlenos = false;
                    break;
                }
            }
             */
            if (estanTodosLlenos)
            {
                switch (tipoListado.Text)
                {
                    case "Proveedores con mayor facturación":
                        gridResultados.DataSource = proveedoresConMayorFacturacion(anio.Text, semestre.SelectedItem.ToString());
                        break;
                    case "Proveedores con mayor porcentaje de descuento ofrecido en sus ofertas":
                        gridResultados.DataSource = proveedoresConMayorPorcentajeDeDescuento(anio.Text, semestre.SelectedItem.ToString());
                        break;
                }
                if (gridResultados.Rows.Count == 0)
                    MessageBox.Show("No se han encontrado datos.", "",
                        System.Windows.Forms.MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Los filtros ingresados son inválidos.", "Error", System.Windows.Forms.MessageBoxButtons.OK);
            }
        }

        private object proveedoresConMayorPorcentajeDeDescuento(string anio, string semestre)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand command = new SqlCommand("[T_REX].ProveedoresConMasDescuento", Database.getConnection()))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@anio", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@semestre", SqlDbType.Int));
                command.Parameters["@anio"].Value = Int32.Parse(anio);
                command.Parameters["@semestre"].Value = Int32.Parse(semestre);
                try
                {
                    dataAdapter.Fill(dataTable);
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return dataTable;
        }

        private object proveedoresConMayorFacturacion(string anio, string semestre)
        {
            DataTable dataTable = new DataTable();
            using (SqlCommand command = new SqlCommand("[T_REX].ProveedoresConMayorFacturacion", Database.getConnection()))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@anio", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@semestre", SqlDbType.Int));
                command.Parameters["@anio"].Value = Int32.Parse(anio);
                command.Parameters["@semestre"].Value = Int32.Parse(semestre);
                try
                {
                    dataAdapter.Fill(dataTable);
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            return dataTable;
        }

        private bool checkearFiltros()
        {
            return this.ValidateChildren(ValidationConstraints.Enabled);
        }

        private void anio_Validating(object sender, CancelEventArgs e)
        {
            if (validateAnio())
            {
                e.Cancel = false;
                anioErrorProvider.SetError(this.anio, String.Empty);
            }
            else
            {
                e.Cancel = true;
                anioErrorProvider.SetError(this.anio, "Debe ingresar el año");
            }
        }

        private bool validateAnio()
        {
            return !String.IsNullOrEmpty(anio.Text);
        }

        private void semestre_Validating(object sender, CancelEventArgs e)
        {
            if (semestre.SelectedItem != null)
            {
                e.Cancel = false;
                semestreErrorProvider.SetError(this.semestre, String.Empty);
            }
            else
            {
                e.Cancel = true;
                semestreErrorProvider.SetError(this.semestre, "Debe indicar el semestre");
            }
        }

        private void tipoListado_Validating(object sender, CancelEventArgs e)
        {
            if (semestre.SelectedItem != null)
            {
                e.Cancel = false;
                tipoErrorProvider.SetError(this.tipoListado, String.Empty);
            }
            else
            {
                e.Cancel = true;
                tipoErrorProvider.SetError(this.tipoListado, "Debe ingresar la categoría");
            }
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            this.gridResultados.DataSource = new DataTable();
            this.anio.Clear();
            this.semestre.SelectedIndex = -1;
            this.tipoListado.SelectedIndex = -1;
        }

        private void gridResultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void anio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ListadoEstadistico_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
