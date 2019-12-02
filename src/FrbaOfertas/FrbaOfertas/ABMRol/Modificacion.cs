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
using FrbaOfertas.Models.Funcionalidades;
using FrbaOfertas.Utils;
using FrbaOfertas.Models.Roles;

namespace FrbaOfertas.ABMRol
{
    public partial class Modificacion : Form
    {
        Rol rol;
        RolDAO rolDao = new RolDAO();
        public Modificacion(Rol _rol)
        {
            InitializeComponent();
            this.rol = _rol;
            NombreTextBox.Text = rol.nombre;
            btn_activar.Visible = rol.activo;
            populateFuncionalidades(rol);
            var funcionalidades = rolDao.getFuncionalidades();
            foreach (Funcionalidad funcionalidad in funcionalidades)
            {
                comboBoxFuncionalidades.Items.Add(funcionalidad);
            }
        }

        private void populateFuncionalidades(Rol rol)
        {

            table_funcionalidades.DataSource = rolDao.getFuncionalidadesXRol(rol);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void table_funcionalidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == table_funcionalidades.Columns["Eliminar"].Index)
                {
                    table_funcionalidades.Rows.RemoveAt(e.RowIndex);
                    ((DataTable)table_funcionalidades.DataSource).Rows.RemoveAt(e.RowIndex); 
                }
            }

        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            NombreTextBox.Text = rol.nombre;
            table_funcionalidades.DataSource = rolDao.getFuncionalidades(rol.id);
            
        }

        private void btn_activar_Click(object sender, EventArgs e)
        {
            SqlCommand procedure = Utils.Database.createCommand("T_REX.AltaRol");
            procedure.Parameters.Add("@nombre_rol", SqlDbType.NVarChar).Value = NombreTextBox.Text;
            procedure.Parameters.Add("@activo", SqlDbType.Bit).Value = 1;
            Utils.Database.executeProcedure(procedure);

           
            MessageBox.Show("Se activo el rol");
        }

        private void BotonAgregar_Click(object sender, EventArgs e)
        {

            Funcionalidad funcionalidad = (Funcionalidad)comboBoxFuncionalidades.SelectedItem;
            DataTable dt = table_funcionalidades.DataSource as DataTable;
            if (dt.Select("func_id = " + funcionalidad.id).Count() > 0)
               MessageBox.Show("Ya contiene esa funcionalidad");
            else
            {
                if (funcionalidad != null)
                {

                    DataRow row = dt.NewRow();
                    row["func_id"] = funcionalidad.id;
                    row["func_detalle"] = funcionalidad.nombre;
                    dt.Rows.Add(row);
                }
            }  
        }


        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {

                    DataTable dt = table_funcionalidades.DataSource as DataTable;
                    DataTable funcionalidades = dt.Copy();
                    rolDao.updateRol(rol.id, NombreTextBox.Text, funcionalidades);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
          
           
        }

        private void NombreTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(NombreTextBox.Text))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                errorProvider.SetError(NombreTextBox, "Debe ingresar un nombre");
            }
        }

        private void FormularioModificacion_Load(object sender, EventArgs e)
        {

        }

        private void btn_atras_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
