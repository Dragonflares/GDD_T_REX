using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Models;

namespace FrbaOfertas
{
    public partial class PantallaPrincipal : Form
    {
        private Dictionary<String, Button> funcionalidades = new Dictionary<String, Button>();
        private string userRole;
        private string username;
        public PantallaPrincipal(String rol, string _username)
        {
            InitializeComponent();
            userRole = rol;
            showFuncionalidades(rol);
            username = _username;
        }

        private void PantallaPrincial_Load(object sender, EventArgs e)
        {

        }

        private void showFuncionalidades(string rol)
        {
            SqlCommand obtenerFuncionalidades = FrbaOfertas.Utils.Database.createCommand("SELECT f.descripcion FROM [GD2C2019].[T_REX].Funcionalidad f" + 
                " JOIN [GD2C2019].[T_REX].Funcionalidad_Rol fr on fr.id_funcionalidad = f.id_funcionalidad" +
                " JOIN [GD2C2019].[T_REX].Rol r on r.id_rol = fr.id_rol WHERE r.nombre = @rol");
            obtenerFuncionalidades.Parameters.Add("@rol", SqlDbType.NChar).Value = rol;
            DataTable tablaFunc = Utils.Database.getData(obtenerFuncionalidades);

            foreach (DataRow row in tablaFunc.Rows)
            {
                comboBox1.Items.Add(row["descripcion"]); 
            }           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Login.CambioPassword().Show(); //Hay que pasarle el cliente/proveedor
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new Login.PantallaLogin().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "ABM ROL":
                {
                    this.Hide();
                    new ABMRol.ABMRol().Show(); 
                    break;
                }
                case "ABM CLIENTE":
                {
                    this.Hide();
                    new ABMCliente.ABMCliente().Show();
                    break;
                }
                case "ABM PROVEEDOR":
                {
                    this.Hide();
                    new ABMProveedor.ABMProveedor().Show();
                    break;
                }
                case "FACTURACION PROVEEDOR":
                {
                    this.Hide();
                    new Facturar.Facturar().Show();
                    break;
                }
                case "CREAR OFERTA":
                {
                    this.Hide();
                    new CrearOferta.CrearOferta(userRole, username).Show();
                    break;
                }
                case "LISTADO ESTADISTICO":
                {
                    this.Hide();
                    new ListadoEstadistico.ListadoEstadistico().Show();
                    break;
                }
                case "COMPRAR OFERTA":
                {
                    this.Hide();
                    new ComprarOferta.ComprarOferta().Show();
                    break;
                }
                case "CARGAR CREDITO":
                {
                    this.Hide();
                    new CargaCredito.CargaCredito().Show();
                    break;
                }
                case "CONSUMO DE OFERTA":
                {
                    this.Hide();
                    new CanjeCupon.CanjeCupon().Show();
                    break;
                }
                default:
                {
                    MessageBox.Show("Debe seleccionar una funcionalidad!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }

            }
        }
    }
}
