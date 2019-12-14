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
            contrasenia.Text = target.pass;
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
                userDAO.guardarUsuario(target.id, nombreUsuario.Text, contrasenia.Text);
            else
                userDAO.guardarUsuario(null, nombreUsuario.Text, contrasenia.Text);
            MessageBox.Show("Usuario guardado con éxito.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
