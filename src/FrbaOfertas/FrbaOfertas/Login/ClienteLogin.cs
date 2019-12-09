using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Models.Usuarios;
using FrbaOfertas.Utils;
using FrbaOfertas.Models.Clientes;
using FrbaOfertas.Models;
using FrbaOfertas.Models.Roles;
using FrbaOfertas.Models.Proveedores;


namespace FrbaOfertas.Login
{
    public partial class ClienteLogin : Form
    {
        private RolDAO rolDAO = new RolDAO();
        private UsuarioDAO userDAO = new UsuarioDAO();
        private ClienteDAO cliDao = new ClienteDAO();
        private ProveedorDAO provDAO = new ProveedorDAO();

        public ClienteLogin()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            showRoles();
            
        }
        private void showRoles()
        {
            SqlCommand obtenerRoles = FrbaOfertas.Utils.Database.createCommand("SELECT r.nombre FROM [GD2C2019].[T_REX].Rol r WHERE r.estado = 1");
            DataTable tablaFunc = Utils.Database.getData(obtenerRoles);

            foreach (DataRow row in tablaFunc.Rows)
            {
                comboBox1.Items.Add(row["nombre"]);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand login = Database.createCommand("[GD2C2019].[T_REX].LogearUsuario");
            login.Parameters.AddWithValue("username", textBox1.Text);
            login.Parameters.AddWithValue("password", textBox2.Text);
            login.Parameters.AddWithValue("tipoUsuario", comboBox1.Text);

            try
            {
                Database.executeProcedure(login);
                //Utils.Database.executeProcedure(login);
                Usuario user = userDAO.getUsuario(textBox1.Text);
                user.rolActivo = rolDAO.getRol(comboBox1.Text);
                switch(comboBox1.Text)
                {
                    case "Cliente":
                        {
                            Cliente cliente = cliDao.getClienteXUsuario(user.id);
                            user.cliente = cliente;
                            break;
                        }
                    case "Proveedor":
                        {
                            //TODO Hace el ingreso de proveedor
                            Proveedor proveedor = provDAO.getProveedorXUsuario(user.id);
                            user.proveedor = proveedor;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                PantallaPrincipal pantalla = new PantallaPrincipal(user);
                pantalla.Owner = this;
                pantalla.Show();
                this.Hide();
                
                /*DataTable tablaFunc = Utils.Database.getDataProcedure(login);
                if (!tablaFunc.HasErrors)
                {
                    this.Hide();
                    new PantallaPrincipal(comboBox1.Text, textBox1.Text).Show();
                }
                 */
                
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message, "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Debe indicar el rol sobre el que crea el Usuario!", "ERROR",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(comboBox1.Text == "Proveedor")
            {
                PrimerLoginProveedor login = new PrimerLoginProveedor();
                login.Owner = this;
                login.Show();
                this.Hide();
            }
            else if (comboBox1.Text == "Cliente")
            {
                PrimerLoginCliente login = new PrimerLoginCliente();
                login.Owner = this;
                login.Show();
                this.Hide();
            }
            else
            {
                NuevoUser login = new NuevoUser(comboBox1.Text);
                login.Owner = this;
                login.Show();
                this.Hide();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Administrativo")
            {
                label4.Visible = false;
                label5.Visible = false;
            }
            else
            {
                label4.Visible = true;
                label5.Visible = true;
            }
        }
    }
}
