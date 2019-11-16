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
            using (GD2C2019Entities db = new GD2C2019Entities())
            {
                var funcionalidad = (from func in db.FUNCIONALIDAD
                                     join fr in db.FUNCIONALIDAD_ROL on func.id_funcionalidad equals fr.id_funcionalidad
                                     join r in db.ROL on fr.id_rol equals r.id_rol
                                     where r.nombre == rol
                                     select new
                                     {
                                         nombre = func.descripcion
                                     });
                comboBox1.DataSource = funcionalidad.ToList();
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
    }
}
