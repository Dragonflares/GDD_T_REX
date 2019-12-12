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
    public partial class PrimerLoginCliente : Form
    {
        private ClienteDAO cliDao = new ClienteDAO();

        public PrimerLoginCliente()
        {
            InitializeComponent();
            contrasenia.PasswordChar = '*';
            confirmContrasenia.PasswordChar = '*';
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
                SqlCommand chequearUser = FrbaOfertas.Utils.Database.createCommand("[GD2C2019].[T_REX].ExisteUsuarioConNombre");

                chequearUser.Parameters.AddWithValue("username", nombreUsuario.Text);
                SqlParameter result = new SqlParameter("@out", SqlDbType.Bit, 1000);
                result.Direction = ParameterDirection.Output;
                chequearUser.Parameters.Add(result);

                Database.executeProcedure(chequearUser);

                Boolean userid = (Boolean)result.Value;

                int id = 0;
                Cliente cliente;
                Usuario user = null;
                if (!userid)
                {
                    SqlCommand query = Utils.Database.createCommand("SELECT max (id_cliente) FROM [T_REX].Cliente");
                    id = Utils.Database.executeScalar(query) + 1;
                    cliente = new Cliente();
                    cliente.id = id;
                    cliente.nombres = nombre.Text;
                    cliente.apellido = apellido.Text;
                    cliente.mail = mail.Text;
                    cliente.tipoDocumento = comboBox1.Text;
                    cliente.nroDocumento = System.Convert.ToInt32(textBox2.Text);
                    cliente.telefono = System.Convert.ToInt32(telefono.Text);
                    cliente.fechaNacimiento = dateTimePicker1.Value;

                    SqlCommand query2 = Utils.Database.createCommand("SELECT max (id_domicilio) FROM [T_REX].Domicilio");

                    int idDom = Utils.Database.executeScalar(query2) + 1;
                    string calleBonita = calle.Text + numeroCalle.Text;
                    cliente.direccion = new Direccion(idDom, calleBonita,
                        piso.Text, codigoPostal.Text, localidad.Text, depto.Text);

                    Rol rolAct = new Rol(2, "Cliente");

                    SqlCommand query3 = Utils.Database.createCommand("SELECT max (id_usuario) FROM [T_REX].Usuario");
                    int trueUserId = Utils.Database.executeScalar(query3) + 1;
                    user = new Usuario(trueUserId, nombreUsuario.Text, contrasenia.Text, rolAct, cliente, null);
                }
                else
                {
                    SqlCommand cheque = FrbaOfertas.Utils.Database.createCommand("SELECT u.id_usuario FROM [GD2C2019].[T_REX].Usuario u" +
                    " WHERE u.userName = @nombre");

                    cheque.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = nombreUsuario.Text;

                    string id_nueva = Database.executeScalar(cheque).ToString();


                    id = System.Convert.ToInt32(id_nueva);
                    cliente = cliDao.getClienteXUsuario(id);
                    if (cliente != null)
                    {
                        MessageBox.Show("Este usuario ya tiene un perfil de Cliente asociado.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        if (contrasenia.Text != cliente.usuario.pass)
                        {
                            MessageBox.Show("Contraseñas incorrectas.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        SqlCommand query = Utils.Database.createCommand("SELECT max (id_cliente) FROM [T_REX].Cliente");
                        id = Utils.Database.executeScalar(query) + 1;
                        cliente = new Cliente();
                        cliente.id = id;
                        cliente.nombres = nombre.Text;
                        cliente.apellido = apellido.Text;
                        cliente.mail = mail.Text;
                        cliente.tipoDocumento = comboBox1.Text;
                        cliente.nroDocumento = System.Convert.ToInt32(textBox2.Text);
                        cliente.telefono = System.Convert.ToInt32(telefono.Text);

                        SqlCommand query2 = Utils.Database.createCommand("SELECT max (id_domicilio) FROM [T_REX].Domicilio");

                        int idDom = Utils.Database.executeScalar(query2) + 1;
                        string calleBonita = calle.Text + numeroCalle.Text;
                        cliente.direccion = new Direccion(idDom, calleBonita,
                            piso.Text, codigoPostal.Text, localidad.Text, depto.Text);

                        Rol rolAct = new Rol(2, "Cliente");

                        int trueUserId = System.Convert.ToInt32(userid);

                        user = new Usuario(trueUserId, nombreUsuario.Text, contrasenia.Text, rolAct, cliente, null);
                    }
                    
                }
                cliDao.guardarCliente(null, cliente.nombres, cliente.apellido, cliente.tipoDocumento, cliente.nroDocumento,
                    cliente.fechaNacimiento, cliente.mail, cliente.telefono, user.nombre, user.pass, cliente.direccion.calle,
                    cliente.direccion.piso, cliente.direccion.departamento, cliente.direccion.localidad, cliente.direccion.codigopostal);
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrimerLoginCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

    }
}
