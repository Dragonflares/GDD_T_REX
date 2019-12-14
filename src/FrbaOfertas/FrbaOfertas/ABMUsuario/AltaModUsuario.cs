using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Utils;
using FrbaOfertas.Models.Usuarios;


namespace FrbaOfertas.ABMUsuario
{
    public partial class AltaModUsuario : Form
    {
        UsuarioDAO userDAO = new UsuarioDAO();
        Usuario target;
        Boolean theresAnUser;
        ListadoUsuario formAnt;
        public AltaModUsuario(Usuario user, ListadoUsuario form)
        {
            formAnt = form;
            theresAnUser = true;
            InitializeComponent();
            target = user;
            nombreUsuario.Text = target.nombre;
            if (target.estado == 1)
            {
                textBox1.Text = "Habilitado";
            }
            else
            {
                textBox1.Text = "Inhabilitado";
            }
            textBox1.Enabled = false;
        }

        public AltaModUsuario()
        {
            theresAnUser = false;
            InitializeComponent();
            button1.Visible = false;
            textBox1.Visible = false;
            label4.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void registrarse_Click(object sender, EventArgs e)
        {
            if (theresAnUser)
            {
                if (target.nombre != nombreUsuario.Text)
                {
                    userDAO.cambiarUsernameModoAdmin(target.id, nombreUsuario.Text);
                    if (contrasenia.Text != "")
                    {
                        userDAO.cambiarContraseñaAdmin(target.id, contrasenia.Text);
                    }
                }
                else
                {
                    if (contrasenia.Text != "")
                    {
                        userDAO.cambiarContraseñaAdmin(target.id, contrasenia.Text);
                    }
                    else
                    {
                        MessageBox.Show("No habia cambios que guardar...", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }

                }
            }
            else
            {
                userDAO.guardarUsuario(null, nombreUsuario.Text, contrasenia.Text);
                MessageBox.Show("Usuario guardado con éxito.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (target.estado == 1)
                userDAO.eliminarUsuario(target.id);
            else
                userDAO.HabilitarUsuario(target.id);
            if (target.estado == 1)
            {
                target.estado = 0;
                textBox1.Text = "Inhabilitado";
            }
            else
            {
                target.estado = 1;
                textBox1.Text = "Habilitado";
            }
            formAnt.loadUsuarios();
        }
    }
}
