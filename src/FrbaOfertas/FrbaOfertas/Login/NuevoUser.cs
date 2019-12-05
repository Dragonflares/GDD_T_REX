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
using System.Data.SqlClient;
using FrbaOfertas.Utils;
using FrbaOfertas.Models.Clientes;
using FrbaOfertas.Models;
using FrbaOfertas.Models.Roles;

namespace FrbaOfertas.Login
{
    public partial class NuevoUser : Form
    {
        private RolDAO rolDAO = new RolDAO();
        private UsuarioDAO userDAO = new UsuarioDAO();
        private string rol;

        public NuevoUser(string _rol)
        {
            rol = _rol;
            InitializeComponent();
            textBox1.Text = rol;
            textBox1.Enabled = false;
        }

        private void registrarse_Click(object sender, EventArgs e)
        {
            Boolean estanTodosLlenos = true;
            foreach (Control x in this.Controls)
            {
                if (x is TextBox && x.Text == "")
                {
                    estanTodosLlenos = false;
                    break;
                }
            }
            if (estanTodosLlenos)
            {
                SqlCommand chequearUser = FrbaOfertas.Utils.Database.createCommand("SELECT u.id_usuario FROM [GD2C2019].[T_REX].Usuario u" +
                                    " WHERE u.userName = @nombre");
                chequearUser.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombreUsuario.Text;
                string userid = Database.executeScalar(chequearUser).ToString();
                Usuario user = null;
                if (userid == null)
                {
                    Rol rolAct = new Rol(2, "Cliente");
                    SqlCommand query3 = Utils.Database.createCommand("SELECT max (id_usuario) FROM [T_REX].Usuario");
                    int trueUserId = Utils.Database.executeScalar(query3) + 1;
                    user = new Usuario(trueUserId, nombreUsuario.Text, contrasenia.Text, rolAct, null, null);
                    userDAO.guardarCliente(user.id, user.nombre, user.pass);
                }
                else
                {
                    user = userDAO.getUsuarioById(System.Convert.ToInt32(userid));
                    if (contrasenia.Text != user.pass)
                    {
                        MessageBox.Show("Contraseñas incorrectas.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int trueUserId = System.Convert.ToInt32(userid);
                    Rol rolAct = rolDAO.getRol(rol);
                    user = new Usuario(trueUserId, nombreUsuario.Text, contrasenia.Text, rolAct, null, null);
                }

                PantallaPrincipal pantalla = new PantallaPrincipal(user);
                pantalla.Owner = this.Owner;
                pantalla.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tiene que completar todos los campos para registrarse.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
