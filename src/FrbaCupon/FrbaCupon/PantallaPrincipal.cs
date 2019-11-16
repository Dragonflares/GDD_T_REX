using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaCupon
{
    public partial class PantallaPrincipal : Form
    {
        private Dictionary<String, Button> funcionalidades = new Dictionary<String,Button>();

        public PantallaPrincipal(String rol)
        {
            InitializeComponent();
            loadFuncionalidades();
            showFuncionalidades(rol);
        }

        private void PantallaPrincial_Load(object sender, EventArgs e)
        {

        }

        private void loadFuncionalidades()
        {

        }

        private void showFuncionalidades(string rol)
        {
             SqlCommand command = FrbaCupon.Utils.Database.createCommand("SELECT [descripcion]" +
               " FROM [GD2C2019].[T_REX].[FUNCIONALIDAD_ROL] WHERE nombre = @rol");
            command.Parameters.Add("@rol",SqlDbType.NChar).Value = rol;
            DataTable table = Utils.Database.getData(command);

            List<String> funcionalidadesRol = table.Rows.Cast<DataRow>().
                Select(row => row[0].ToString()).ToList<String>();

            funcionalidades.Where(f => !funcionalidadesRol.Contains(f.Key)).ToList().ForEach(f => { f.Value.Visible = false; });
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
    }
}
