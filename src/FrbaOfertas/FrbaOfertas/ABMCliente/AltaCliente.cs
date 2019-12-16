using FrbaOfertas.Models.Clientes;
using FrbaOfertas.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.ABMCliente
{
    public partial class AltaCliente : Form
    {
        ClienteDAO clienteDao = new ClienteDAO();
        Cliente cliente = null;
        private string nuevaPass = null;
        private string defaultPassText = "******";
        public AltaCliente()
        {
            InitializeComponent();
            friendlyValidater();
            this.text_pass.TextChanged += new System.EventHandler(this.text_pass_TextChanged);
            text_credito.Text = "200";
        }

        public AltaCliente(Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
            this.text_pass.Text = this.defaultPassText; // Esto tiene que ponerse antes de que se asigne el EventHandler
            this.text_pass.TextChanged += new System.EventHandler(this.text_pass_TextChanged);

            this.text_usuario.Text = cliente.usuario.nombre;
            this.text_nombre.Text = cliente.nombres;
            this.text_apellido.Text = cliente.apellido;
            this.text_telefono.Text = cliente.telefono.ToString();
            this.text_email.Text = cliente.mail;
            this.text_credito.Text = cliente.credito.ToString();
            this.text_nro_dni.Text = cliente.nroDocumento.ToString();
            this.combo_tipo_dni.Text = cliente.tipoDocumento;
            this.datepicker_fecha_nac.Value = cliente.fechaNacimiento;

            this.text_calle.Text = cliente.direccion.calle;
            this.text_piso.Text = cliente.direccion.piso;
            this.text_dto.Text = cliente.direccion.departamento;
            this.text_localidad.Text = cliente.direccion.localidad;
            this.text_cod_postal.Text = cliente.direccion.codigopostal;

            friendlyValidater();
        }

        private void friendlyValidater()
        {
            text_piso.KeyPress += numeric_KeyPress;
            text_telefono.KeyPress += numeric_KeyPress;
            text_nro_dni.KeyPress += numeric_KeyPress;
            text_nombre.KeyPress += noNumber_KeyPress;
            text_apellido.KeyPress += noNumber_KeyPress;
        }

        private void numeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) || (sender as TextBox).TextLength > 10)
            {
                e.Handled = true;
            }

        }

        private void noNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }

        }


        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label13_Click(object sender, EventArgs e)
        {

        }

        private void Label14_Click(object sender, EventArgs e)
        {

        }

        private void TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void ABMCliente_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (this.formEsInvalido())
            {
                MessageBox.Show("LLenar campos vacios");
            }

            else
            {
                Boolean estanTodosLlenos = true;
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
                if (estanTodosLlenos)
                {
                    int? idCliente = null;
                    if (this.cliente != null) { idCliente = this.cliente.id; }
                    try
                    {
                        this.clienteDao.guardarCliente(idCliente, this.text_nombre.Text, this.text_apellido.Text, this.combo_tipo_dni.Text, int.Parse(this.text_nro_dni.Text), this.datepicker_fecha_nac.Value, this.text_email.Text, int.Parse(this.text_telefono.Text), this.text_usuario.Text, this.nuevaPass, this.text_calle.Text, this.text_piso.Text, this.text_dto.Text, this.text_localidad.Text, this.text_cod_postal.Text);
                        MessageBox.Show("Cliente guardado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message, "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Tiene que completar todos los campos para registrarse.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        private Boolean formEsInvalido()
        {
            return String.IsNullOrEmpty(this.text_nombre.Text)
                || String.IsNullOrEmpty(this.text_apellido.Text)
                || String.IsNullOrEmpty(this.text_usuario.Text)
                || String.IsNullOrEmpty(this.text_pass.Text)
                || String.IsNullOrEmpty(this.text_email.Text)
                || String.IsNullOrEmpty(this.text_telefono.Text)
                || String.IsNullOrEmpty(this.datepicker_fecha_nac.Text)
                || String.IsNullOrEmpty(this.text_calle.Text)
                || String.IsNullOrEmpty(this.text_piso.Text)
                || String.IsNullOrEmpty(this.text_dto.Text)
                || String.IsNullOrEmpty(this.text_localidad.Text)
                || String.IsNullOrEmpty(this.text_cod_postal.Text)
                || String.IsNullOrEmpty(this.text_nro_dni.Text);
                
        }

        private void text_pass_TextChanged(object sender, EventArgs e)
        {
            this.nuevaPass = this.text_pass.Text;
        }

        private void text_pass_Enter(object sender, EventArgs e)
        {
            if(this.text_pass.Text == this.defaultPassText) 
            {
                this.text_pass.Clear();
            }
        }
    }
}
