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
            new Login.CambioPassword().Show(); //Hay que pasarle el cliente/proveedor
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Owner.Show();
            this.Close();
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
                case "ABM Clientes":
                {
                    this.Hide();
                    new ABMCliente.ListadoCliente().Show();
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
                    new CrearOferta.CrearOferta(user).Show();
                    this.Hide();
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
                    new ComprarOferta.ComprarOferta(user.nombre, user.rolActivo.nombre).Show();
                    break;
                }
                case "Cargar Credito":
                {
                    new CargaCredito.CargaCredito(user).Show();
                    this.Hide();
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
