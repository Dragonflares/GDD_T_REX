using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Models.Usuarios;
using FrbaOfertas.Models.Roles;

namespace FrbaOfertas
{
    public partial class PantallaPrincipal : Form
    {
        private Boolean cerrandoSession = false;
        private Dictionary<String, Button> funcionalidades = new Dictionary<String, Button>();
        public Usuario user;
        public PantallaPrincipal(Usuario usuario)
        {
            InitializeComponent();
            user = usuario;
            showFuncionalidades(user.rolActivo);
        }

        private void PantallaPrincial_Load(object sender, EventArgs e)
        {

        }

        private void showFuncionalidades(Rol rol)
        {
            SqlCommand obtenerFuncionalidades = FrbaOfertas.Utils.Database.createCommand("SELECT f.descripcion FROM [GD2C2019].[T_REX].Funcionalidad f" + 
                " JOIN [GD2C2019].[T_REX].Funcionalidad_Rol fr on fr.id_funcionalidad = f.id_funcionalidad" +
                " JOIN [GD2C2019].[T_REX].Rol r on r.id_rol = fr.id_rol WHERE r.id_rol = @rol");
            obtenerFuncionalidades.Parameters.Add("@rol", SqlDbType.NChar).Value = rol.id;
            DataTable tablaFunc = Utils.Database.getData(obtenerFuncionalidades);

            foreach (DataRow row in tablaFunc.Rows)
            {
                comboBox1.Items.Add(row["descripcion"]); 
            }           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Login.CambioPassword(this.user).ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.cerrandoSession = true;
            this.Owner.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch ((string)comboBox1.SelectedItem)
            {
                case "ABM Rol":
                {
                    ABMRol.ABMRol pantalla = new ABMRol.ABMRol(this);
                    pantalla.Owner = this;
                    pantalla.Show();
                    this.Hide();
                    break;
                }
                case "ABM Clientes":
                {
                    ABMCliente.ListadoCliente pantalla = new ABMCliente.ListadoCliente();
                    pantalla.Owner = this;
                    pantalla.Show();
                    this.Hide();
                    break;
                }
                case "ABM Proveedor":
                {
                    ABMProveedor.ABMProveedor pantalla = new ABMProveedor.ABMProveedor();
                    pantalla.Owner = this;
                    pantalla.Show();
                    this.Hide();
                    break;
                }
                case "Facturacion Proveedor":
                {
                    Facturar.Facturar pantalla = new Facturar.Facturar(user);
                    pantalla.Owner = this;
                    pantalla.Show();
                    this.Hide();
                    break;
                }
                case "Publicar Oferta":
                {
                    CrearOferta.CrearOferta pantalla = new CrearOferta.CrearOferta(user);
                    pantalla.Owner = this;
                    pantalla.Show();
                    this.Hide();
                    break;
                }
                case "Listado Estadistico":
                {
                    ListadoEstadistico.ListadoEstadistico pantalla = new ListadoEstadistico.ListadoEstadistico(user);
                    pantalla.Owner = this;
                    pantalla.Show();
                    this.Hide();
                    break;
                }
                case "Comprar Oferta":
                {

                    ComprarOferta.ComprarOferta pantalla = new ComprarOferta.ComprarOferta(user);
                    pantalla.Owner = this;
                    pantalla.Show();
                    this.Hide();
                    break;
                }
                case "Cargar Credito":
                {
                    CargaCredito.CargaCredito pantalla = new CargaCredito.CargaCredito(user);
                    pantalla.Owner = this;
                    pantalla.Show();
                    this.Hide();
                    break;
                }
                case "Consumo Oferta":
                {
                    this.Hide();
                    if (user.rolActivo.id == 3)
                    {
                        CanjeCupon.CanjeCupon pantalla = new CanjeCupon.CanjeCupon(user);
                        pantalla.Owner = this;
                        pantalla.Show();
                    }
                    else
                    {
                        CanjeCupon.ListadoProveedor pantalla = new CanjeCupon.ListadoProveedor();
                        pantalla.Owner = this;
                        pantalla.Show();
                    }
                    break;
                }
                default:
                {
                    MessageBox.Show("Debe seleccionar una funcionalidad!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }

            }
        }

        private void PantallaPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!this.cerrandoSession)
            {
                Application.Exit();
            }
        }
    }
}
