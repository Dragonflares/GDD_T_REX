using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Models.Facturas;


namespace FrbaOfertas.Facturar
{
    public partial class InfoFactura : Form
    {
        public Factura factura;
        public InfoFactura(Factura fact)
        {
            factura = fact;
            InitializeComponent();
            textBox1.Text = factura.nro_factura.ToString();
            textBox2.Text = factura.proveedor.razonSocial;
            textBox3.Text = factura.importe_fact.ToString();
            textBox4.Text = factura.fecha_inicio.ToString();
            textBox5.Text = factura.fecha_fin.ToString();
            textBox6.Text = factura.tipo_fact;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
