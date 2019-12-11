using FrbaOfertas.Models.Proveedores;
using FrbaOfertas.Models.Rubros;
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

namespace FrbaOfertas.ABMProveedor
{
    public partial class AltaProveedor : Form
    {
        RubroDAO rubroDao = new RubroDAO();
        ProveedorDAO proveedorDao = new ProveedorDAO();
        Proveedor proveedor = null;

        public AltaProveedor()
        {
            InitializeComponent();
            this.cargarRubros();
        }

        public AltaProveedor(Proveedor proveedor)
        {
            InitializeComponent();
            this.cargarRubros();

            this.proveedor = proveedor;
            this.text_usuario.Text = proveedor.usuario.nombre;
            this.text_pass.Text = proveedor.usuario.pass;
            this.text_razonsocial.Text = proveedor.razonSocial;
            this.text_cuit.Text = proveedor.CUIT;
            this.text_telefono.Text = proveedor.telefono.ToString();
            this.text_email.Text = proveedor.mail;
            this.combo_rubro.Text = proveedor.rubro;

            this.text_calle.Text = proveedor.direccion.calle;
            this.text_piso.Text = proveedor.direccion.piso;
            this.text_dto.Text = proveedor.direccion.departamento;
            this.text_localidad.Text = proveedor.direccion.localidad;
            this.text_cod_postal.Text = proveedor.direccion.codigopostal;
        }

        private void cargarRubros()
        {
            List<Rubro> rubros = this.rubroDao.getRubros();
            foreach (Rubro rubro in rubros)
            {
                this.combo_rubro.Items.Add(rubro.nombre);
            }
        }

        private void btn_volver_Click(object sender, EventArgs e)
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
                int? idProveedor = null;
                if (this.proveedor != null) { idProveedor = this.proveedor.id; }

                this.proveedorDao.guardarProveedor(idProveedor, this.text_razonsocial.Text, this.text_cuit.Text, this.text_email.Text, this.combo_rubro.Text, int.Parse(this.text_telefono.Text), this.text_usuario.Text, this.text_pass.Text, this.text_calle.Text, this.text_piso.Text, this.text_dto.Text, this.text_localidad.Text, this.text_cod_postal.Text);
                
                this.Close();

            }
        }

        private Boolean formEsInvalido()
        {
            return String.IsNullOrEmpty(this.text_usuario.Text)
                || String.IsNullOrEmpty(this.text_pass.Text)
                || String.IsNullOrEmpty(this.text_email.Text)
                || String.IsNullOrEmpty(this.text_telefono.Text)
                || String.IsNullOrEmpty(this.text_razonsocial.Text)
                || String.IsNullOrEmpty(this.text_cuit.Text)
                || String.IsNullOrEmpty(this.combo_rubro.Text)
                || String.IsNullOrEmpty(this.text_calle.Text)
                || String.IsNullOrEmpty(this.text_piso.Text)
                || String.IsNullOrEmpty(this.text_dto.Text)
                || String.IsNullOrEmpty(this.text_localidad.Text)
                || String.IsNullOrEmpty(this.text_cod_postal.Text);

        }
    }
}
