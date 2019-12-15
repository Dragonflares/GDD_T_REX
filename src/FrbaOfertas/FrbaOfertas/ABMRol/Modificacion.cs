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
            btn_activar.Visible = !rol.activo;
            populateFuncionalidades(rol);
            var funcionalidades = rolDao.getFuncionalidades();
            foreach (Funcionalidad funcionalidad in funcionalidades)
            {
                comboBoxFuncionalidades.Items.Add(funcionalidad);
            }
            NombreTextBox.KeyPress += noNumber_KeyPress;
        }

        private void noNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
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
            rolDao.activar_rol(rol);
            MessageBox.Show("Se activo el rol");
        }

        private void BotonAgregar_Click(object sender, EventArgs e)
        {

            Funcionalidad funcionalidad = (Funcionalidad)comboBoxFuncionalidades.SelectedItem;
            DataTable dt = table_funcionalidades.DataSource as DataTable;
            if (dt.Select("id = " + funcionalidad.id).Count() > 0)
               MessageBox.Show("Ya contiene esa funcionalidad");
            else
            {
                if (funcionalidad != null)
                {

                    DataRow row = dt.NewRow();
                    row["id"] = funcionalidad.id;
                    row["Funcionalidad"] = funcionalidad.nombre;
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

                    DataTable dt = new DataTable();
                    dt.Columns.Add("id");
                    dt.Columns.Add("Funcionalidad");

                    foreach (DataGridViewRow rowGrid in table_funcionalidades.Rows)
                    {
                        DataRow row = dt.NewRow();
                        row["id"] = rowGrid.Cells[1].Value;
                        row["Funcionalidad"] = rowGrid.Cells[2].Value;
                        dt.Rows.Add(row);
                    }
                    DataTable funcionalidades = dt.Copy();
                    List<Funcionalidad> funcsNuevas = funcionalidades.Rows.Cast<DataRow>().
                        Select(row =>
                        {
                            Funcionalidad func = new Funcionalidad(
                                int.Parse(row["id"].ToString()),
                                row["Funcionalidad"].ToString());
                            return func;
                        }).ToList<Funcionalidad>();
                    DataTable funcionalidadesViejas = rolDao.getFuncionalidadesXRol(rol);
                    List<Funcionalidad> funcsViejas = funcionalidadesViejas.Rows.Cast<DataRow>().
                        Select(row =>
                        {
                            Funcionalidad func = new Funcionalidad(
                                int.Parse(row["id"].ToString()),
                                row["Funcionalidad"].ToString());
                            return func;
                        }).ToList<Funcionalidad>();

                    foreach (Funcionalidad funcX in funcsNuevas)
                    {
                        bool failsafe = false;
                        foreach (Funcionalidad funcZ in funcsViejas)
                        {
                            if (funcZ.id == funcX.id)
                            {
                                failsafe = true;
                                break;
                            }
                        }
                        if (!failsafe)
                        {
                            rolDao.agregarFuncionalidad(rol.id, funcX);
                        }
                    }
                    foreach (Funcionalidad funcZ in funcsViejas)
                    {
                        bool failsafe = false;
                        foreach (Funcionalidad funcX in funcsNuevas)
                        {
                            if (funcZ.id == funcX.id)
                            {
                                failsafe = true;
                                break;
                            }
                        }
                        if (!failsafe)
                        {
                            rolDao.sacarFuncionalidad(rol.id, funcZ);
                        }
                    }
                    if (NombreTextBox.Text != rol.nombre)
                    {
                        rolDao.cambiarNombreRol(rol.id, NombreTextBox.Text);
                    }
                    MessageBox.Show("Rol modificado", "ABM Rol", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
