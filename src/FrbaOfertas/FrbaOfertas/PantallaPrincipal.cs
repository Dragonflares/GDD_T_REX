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
        public PantallaPrincipal(string rol, string _username)
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
                    new ABMRol.ABMRol(this).ShowDialog(); 
                    break;
                }
                case "ABM Clientes":
                {
                    new ABMCliente.ABMCliente().ShowDialog();
                    break;
                }
                case "ABM Proveedor":
                {
                    new ABMProveedor.ABMProveedor().ShowDialog();
                    break;
                }
                case "Facturacion Proveedor":
                {
                    new Facturar.Facturar().ShowDialog();
                    break;
                }
                case "Publicar Oferta":
                {
                    new CrearOferta.CrearOferta(userRole, username).ShowDialog();
                    break;
                }
                case "Listado Estadistico":
                {
                    new ListadoEstadistico.ListadoEstadistico().ShowDialog();
                    break;
                }
                case "Comprar Oferta":
                {
                    new ComprarOferta.ComprarOferta(username, userRole).ShowDialog();
                    break;
                }
                case "Cargar Credito":
                {
                    new CargaCredito.CargaCredito().ShowDialog();
                    break;
                }
                case "Consumo Oferta":
                {
                    new CanjeCupon.CanjeCupon().ShowDialog();
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
