﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Models.Usuarios;
using FrbaOfertas.Models.Proveedores;
using System.Data.SqlClient;


namespace FrbaOfertas.CanjeCupon
{
    public partial class CanjeCupon : Form
    {
        private Usuario usuario;
        private Proveedor target;

        public CanjeCupon(Usuario user)
        {
            usuario = user;
            InitializeComponent();
            loadCuponesPorEntregar();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        public void loadCuponesPorEntregar()
        {
            string takecupon = "SELECT cup.id_cupon as id, cup.cupon_fecha_deconsumo as fechaVencimiento, " +
                "offer.descripcion as descripcion, u.username as cliente" +
                "FROM [GD2C2019].[T_REX].[Cupon] cup " + 
                "INNER JOIN [GD2C2019].[T_REX].[Oferta] offer ON offer.id_oferta = cup.id_oferta " +
                "INNER JOIN [GD2C2019].[T_REX].[Compra] comp ON comp.id_compra = cup.id_compra " +
                "INNER JOIN [GD2C2019].[T_REX].[Cliente] cli ON cli.id_cliente = comp.id_cliente " +
                "INNER JOIN [GD2C2019].[T_REX].[Usuario] u ON u.id_usuario = cli.id_usuario " +
                "WHERE p.estado = 1";

            if (!String.IsNullOrEmpty(textBox1.Text)) takecupon += " and lower(of.descripcion) like '%" + textBox1.Text.ToLower() + "%'";



            takecupon += "ORDER BY [id] ASC";
            SqlCommand takeClients = FrbaOfertas.Utils.Database.createCommand(takecupon);
            DataTable table = Utils.Database.getData(takeClients);
            this.dgv_cupon.DataSource = table;
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.dgv_cupon.DataSource;
            if (dt != null)
                dt.Clear();
            this.Controls.Cast<Control>().ToList()
                .Where(c => c is GroupBox)
                .SelectMany(c => c.Controls.Cast<Control>().ToList())
                .ToList().ForEach(c =>
                {
                    if (c is ComboBox)
                        ((ComboBox)c).SelectedIndex = -1;
                    if (c is TextBox)
                        c.Text = null;
                    if (c is MonthCalendar)
                        ((MonthCalendar)c).Visible = false;
                });
            loadCuponesPorEntregar();
        }

        private void dgv_cupon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == dgv_cupon.Columns["Entregar"].Index)
            {
                FrbaOfertas.CanjeCupon.ListadoClientes pantalla = new FrbaOfertas.CanjeCupon.ListadoClientes();
                pantalla.ShowDialog();
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            loadCuponesPorEntregar();
        }
    }
}
