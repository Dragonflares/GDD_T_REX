using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Models.Usuarios;
using FrbaOfertas.Utils;
using System.Data.SqlClient;

namespace FrbaOfertas.ABMUsuario
{
    public partial class ListadoUsuario : Form
    {
        UsuarioDAO userDAO = new UsuarioDAO();
        public ListadoUsuario()
        {
            InitializeComponent();
            loadUsuarios();
        }

        public void loadUsuarios()
        {
            string takeusers = "SELECT u.id_usuario as id, u.username as Nombre, u.estado as estado" +
                " FROM [GD2C2019].[T_REX].[Usuario] u";

            if (!String.IsNullOrEmpty(textBox2.Text)) takeusers += " WHERE lower(u.username) like '%" + textBox2.Text.ToLower() + "%'";


            takeusers += "ORDER BY u.[id_usuario] ASC";
            SqlCommand takeClients = FrbaOfertas.Utils.Database.createCommand(takeusers);
            DataTable table = Utils.Database.getData(takeClients);
            this.dgv_clientes.DataSource = table;
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.dgv_clientes.SelectedRows.Count > 0)
            {
                try
                {
                    int id = (Int32)this.dgv_clientes.SelectedRows[0].Cells["id"].Value;
                    Usuario target = userDAO.getUsuarioById(id);
                    new AltaModUsuario(target, this).ShowDialog();

                }
                catch (SqlException exception)
                {
                    MessageBox.Show(exception.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un Usuario");
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            loadUsuarios();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.dgv_clientes.DataSource;
            if (dt != null)
            {
                dt.Clear();
            }
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
            loadUsuarios();
        }
    }
}
