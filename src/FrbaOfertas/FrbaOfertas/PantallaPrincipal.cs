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
        public string userRole;
        public string username;
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
            this.Owner.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch ((string)comboBox1.SelectedItem)
            {
                case "ABM Rol":
                {
                    this.Hide();
                    new ABMRol.ABMRol(this).Show(); 
                    break;
                }
                case "ABM Cliente":
                {
                    this.Hide();
                    new ABMCliente.ABMCliente().Show();
                    break;
                }
                case "ABM Proveedor":
                {
                    this.Hide();
                    new ABMProveedor.ABMProveedor().Show();
                    break;
                }
                case "Facturacion Proveedor":
                {
                    this.Hide();
                    new Facturar.Facturar().Show();
                    break;
                }
                case "Publicar Oferta":
                {
                    this.Hide();
                    new CrearOferta.CrearOferta(userRole, username).Show();
                    break;
                }
                case "Listado Estadistico":
                {
                    this.Hide();
                    new ListadoEstadistico.ListadoEstadistico().Show();
                    break;
                }
                case "Comprar Oferta":
                {
                    this.Hide();
                    new ComprarOferta.ComprarOferta().Show();
                    break;
                }
                case "Cargar Credito":
                {
                    this.Hide();
                    new CargaCredito.CargaCredito().Show();
                    break;
                }
                case "Consumo Oferta":
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
