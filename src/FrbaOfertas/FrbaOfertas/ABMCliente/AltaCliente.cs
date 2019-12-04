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
        public AltaCliente()
        {
            InitializeComponent();
        }

        public AltaCliente(Cliente cliente)
        {
            InitializeComponent();

            this.cliente = cliente;

            this.text_usuario.Text = cliente.usuario.nombre;
            this.text_pass.Text = cliente.usuario.pass;
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
            if(this.formEsInvalido()) 
            {
                MessageBox.Show("LLenar campos vacios");
            }
            else
            {
                int? idCliente = null;
                if (this.cliente != null) { idCliente = this.cliente.id; } 

                this.clienteDao.guardarCliente(idCliente, this.text_nombre.Text, this.text_apellido.Text, this.combo_tipo_dni.Text, this.text_nro_dni.Text, this.datepicker_fecha_nac.Value, this.text_email.Text, this.text_telefono.Text, this.text_usuario.Text, this.text_pass.Text, this.text_calle.Text, this.text_piso.Text, this.text_dto.Text,this.text_localidad.Text,this.text_cod_postal.Text);
                this.Close();

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
    }
}
