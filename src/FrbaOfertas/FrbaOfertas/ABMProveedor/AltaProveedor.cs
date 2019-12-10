using FrbaOfertas.Models.Proveedores;
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
        ProveedorDAO proveedorDao = new ProveedorDAO();
        Proveedor proveedor = null;

        public AltaProveedor()
        {
            InitializeComponent();
        }

        public AltaProveedor(Proveedor proveedor)
        {
            InitializeComponent();

            this.proveedor = proveedor;
            this.text_usuario.Text = proveedor.usuario.nombre;
            this.text_pass.Text = proveedor.usuario.pass;
            this.text_razonsocial.Text = proveedor.razonSocial;
            this.text_cuit.Text = proveedor.CUIT;
            this.text_telefono.Text = proveedor.telefono.ToString();
            this.text_email.Text = proveedor.mail;

            this.text_calle.Text = proveedor.direccion.calle;
            this.text_piso.Text = proveedor.direccion.piso;
            this.text_dto.Text = proveedor.direccion.departamento;
            this.text_localidad.Text = proveedor.direccion.localidad;
            this.text_cod_postal.Text = proveedor.direccion.codigopostal;
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
