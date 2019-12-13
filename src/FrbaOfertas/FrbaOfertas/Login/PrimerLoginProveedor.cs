using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaOfertas.Models.Proveedores;
using FrbaOfertas.Utils;
using FrbaOfertas.Models.Usuarios;
using FrbaOfertas.Models.Roles;
using FrbaOfertas.Models;


namespace FrbaOfertas.Login
{
    public partial class PrimerLoginProveedor : Form
    {

        ProveedorDAO provDAO = new ProveedorDAO();

        public PrimerLoginProveedor()
        {
            InitializeComponent();
            contrasenia.PasswordChar = '*';
            confirmContrasenia.PasswordChar = '*';
            textBox1.Enabled = false;
            numeroCalle.KeyPress += numeroCalle_KeyPress;
            piso.KeyPress += piso_KeyPress;
            cuit.KeyPress += cuit_KeyPress;
            loadRubros();
        }

        private void loadRubros()
        {
            SqlCommand obtenerRubros = FrbaOfertas.Utils.Database.createCommand("SELECT r.nombreDeRubro FROM [GD2C2019].[T_REX].Rubro r");
            DataTable tablaFunc = Utils.Database.getData(obtenerRubros);

            foreach (DataRow row in tablaFunc.Rows)
            {
                comboBox1.Items.Add(row["nombreDeRubro"]);
            }
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
                if (cuit.Text.Length < 13)
                {
                    MessageBox.Show("El CUIT tiene un formato inválido.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    SqlCommand chequearUser = FrbaOfertas.Utils.Database.createCommand("[GD2C2019].[T_REX].ExisteUsuarioConNombre");

                    chequearUser.Parameters.AddWithValue("username", nombreUsuario.Text);
                    SqlParameter result = new SqlParameter("@out", SqlDbType.Bit, 1000);
                    result.Direction = ParameterDirection.Output;
                    chequearUser.Parameters.Add(result);

                    Database.executeProcedure(chequearUser);

                    Boolean meep = (Boolean)result.Value;
                    int id = 0;
                    Proveedor proveedor;
                    Usuario user = null;
                    if (!meep)
                    {
                        SqlCommand query = Utils.Database.createCommand("SELECT max (id_cliente) FROM [T_REX].Cliente");
                        id = Utils.Database.executeScalar(query) + 1;
                        proveedor = new Proveedor();
                        proveedor.id = id;
                        proveedor.razonSocial = razonSocial.Text;
                        proveedor.CUIT = cuit.Text;
                        proveedor.mail = mail.Text;
                        proveedor.rubro = comboBox1.Text;
                        proveedor.telefono = System.Convert.ToInt32(telefono.Text);

                        SqlCommand query2 = Utils.Database.createCommand("SELECT max (id_domicilio) FROM [T_REX].Domicilio");

                        int idDom = Utils.Database.executeScalar(query2) + 1;
                        string calleBonita = calle.Text + numeroCalle.Text;
                        proveedor.direccion = new Direccion(idDom, calleBonita,
                            piso.Text, codigoPostal.Text, localidad.Text, depto.Text);

                        Rol rolAct = new Rol(3, "Proveedor");

                        SqlCommand query3 = Utils.Database.createCommand("SELECT max (id_usuario) FROM [T_REX].Usuario");
                        int trueUserId = Utils.Database.executeScalar(query3) + 1;
                        user = new Usuario(trueUserId, nombreUsuario.Text, contrasenia.Text, rolAct, null, proveedor);
                    }
                    else
                    {
                        SqlCommand cheque = FrbaOfertas.Utils.Database.createCommand("SELECT u.id_usuario FROM [GD2C2019].[T_REX].Usuario u" +
                        " WHERE u.userName = @nombre");
                        cheque.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombreUsuario.Text;
                        string userid = Database.executeScalar(cheque).ToString();
                        id = System.Convert.ToInt32(userid);
                        proveedor = provDAO.getProveedor(id);
                        if (proveedor != null)
                        {
                            MessageBox.Show("Este usuario ya tiene un perfil de Cliente asociado.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            if (contrasenia.Text != proveedor.usuario.pass)
                            {
                                MessageBox.Show("Contraseñas incorrectas.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            SqlCommand query = Utils.Database.createCommand("SELECT max (id_cliente) FROM [T_REX].Cliente");
                            id = Utils.Database.executeScalar(query) + 1;
                            proveedor = new Proveedor();
                            proveedor.id = id;
                            proveedor.razonSocial = razonSocial.Text;
                            proveedor.CUIT = cuit.Text;
                            proveedor.mail = mail.Text;
                            proveedor.rubro = comboBox1.Text;
                            proveedor.telefono = System.Convert.ToInt32(telefono.Text);

                            SqlCommand query2 = Utils.Database.createCommand("SELECT max (id_domicilio) FROM [T_REX].Domicilio");

                            int idDom = Utils.Database.executeScalar(query2) + 1;
                            string calleBonita = calle.Text + numeroCalle.Text;
                            proveedor.direccion = new Direccion(idDom, calleBonita,
                                piso.Text, codigoPostal.Text, localidad.Text, depto.Text);

                            Rol rolAct = new Rol(3, "Proveedor");

                            int trueUserId = System.Convert.ToInt32(userid);

                            user = new Usuario(trueUserId, nombreUsuario.Text, contrasenia.Text, rolAct, null, proveedor);
                        }

                    }
                    provDAO.guardarProveedor(null, proveedor.razonSocial, proveedor.CUIT, proveedor.mail,
                        proveedor.rubro, proveedor.telefono, user.nombre, user.pass, proveedor.direccion.calle,
                        proveedor.direccion.piso, proveedor.direccion.departamento, proveedor.direccion.localidad,
                        proveedor.direccion.codigopostal);
                    PantallaPrincipal pantalla = new PantallaPrincipal(user);
                    pantalla.Owner = this.Owner;
                    pantalla.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Tiene que completar todos los campos para registrarse.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void numeroCalle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void piso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void cuit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '-')) || ((hasTwo((sender as TextBox).Text) && char.IsDigit(cuit.Text.Last()))))
            {
                if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                    e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) && (cantNumeros(cuit.Text) == 2) && ((sender as TextBox).Text.IndexOf('-') < 0))
            {
                e.Handled = true;
            }
            else if (char.IsDigit(e.KeyChar) && (cantNumeros(cuit.Text) == 10) && !(hasTwo((sender as TextBox).Text)))
            {
                e.Handled = true;
            }
            else if ((e.KeyChar == '-') && (hasTwo((sender as TextBox).Text) || (((sender as TextBox).Text.IndexOf('-') == ((sender as TextBox).Text.Length - 1)))))
            {
                e.Handled = true;
            }
        }

        public int cantNumeros(string lecturer)
        {
            int counter = 0;
            foreach (char letter in lecturer)
            {
                if (char.IsDigit(letter))
                {
                    counter++;
                }
            }
            return counter;
        }

        public Boolean hasTwo(string lecturer)
        {
            int counter = 0;
            foreach (char letter in lecturer)
            {
                if (letter == '-')
                {
                    counter++;
                }
            }
            if (counter > 1)
            {
                return true;
            }
            else
                return false;
        }

        private void PrimerLoginProveedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        // agregar evento de en cambio del texto de nombreUsuario, que haga una busqueda para completar y bloquear los campos de contraseña.
    }
}
