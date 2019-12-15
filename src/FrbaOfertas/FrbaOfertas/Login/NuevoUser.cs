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
using System.Security.Cryptography;


namespace FrbaOfertas.Login
{
    public partial class NuevoUser : Form
    {
        private RolDAO rolDAO = new RolDAO();
        private UsuarioDAO userDAO = new UsuarioDAO();
        private string rol;
        private ClienteLogin form_ant;
        public NuevoUser(string _rol, ClienteLogin form)
        {
            form_ant = form;
            rol = _rol;
            InitializeComponent();
            textBox1.Text = rol;
            textBox1.Enabled = false;
            contrasenia.PasswordChar = '*';
            confirmContrasenia.PasswordChar = '*';
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
                if (nombreUsuario.Text == "admin")
                {
                    MessageBox.Show("El administrador no puede tener más de un rol.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (contrasenia.Text != confirmContrasenia.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SqlCommand chequearUser = FrbaOfertas.Utils.Database.createCommand("[GD2C2019].[T_REX].ExisteUsuarioConNombre");

                chequearUser.Parameters.AddWithValue("username", nombreUsuario.Text);
                SqlParameter result = new SqlParameter("@out", SqlDbType.Bit, 1000);
                result.Direction = ParameterDirection.Output;
                chequearUser.Parameters.Add(result);

                Database.executeProcedure(chequearUser);

                Boolean userid = (Boolean)result.Value;

                int id = 0;
                Usuario user = null;
                if (!userid)
                {
                    Rol rolAct = rolDAO.getRol(rol);
                    SqlCommand query3 = Utils.Database.createCommand("SELECT max (id_usuario) FROM [T_REX].Usuario");
                    int trueUserId = Utils.Database.executeScalar(query3) + 1;
                    user = new Usuario(trueUserId, nombreUsuario.Text, contrasenia.Text, rolAct, null, null);
                    userDAO.guardarUsuario(null, user.nombre, user.pass);
                }
                else
                {
                    user = userDAO.getUsuario(nombreUsuario.Text);
                    
                    if (!userDAO.validarContrasenia(nombreUsuario.Text, contrasenia.Text))
                    {
                        MessageBox.Show("Contraseñas incorrectas.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("Funciono OK", "Creación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    int trueUserId = System.Convert.ToInt32(userid);
                    Rol rolAct = rolDAO.getRol(rol);
                    user = new Usuario(trueUserId, nombreUsuario.Text, contrasenia.Text, rolAct, null, null);
                }
                userDAO.agregarRolAUsuario(user, user.rolActivo);
                userDAO.eliminarUsuario(user.id);
                MessageBox.Show("Solicitud de nuevo usuario recibida, contacte a un administrador para que le den de alta su cuenta.", "Creación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Tiene que completar todos los campos para registrarse.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NuevoUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
    }
}
