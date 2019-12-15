using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.Models.Roles;
using FrbaOfertas.Models.Funcionalidades;
using FrbaOfertas.Utils;
using FrbaOfertas.Models.Usuarios;


namespace FrbaOfertas.ABMRol
{
    public partial class ABMRol : Form
    {
        public Usuario user { get; set; }
        RolDAO rolDao = new RolDAO();
        public ABMRol(Usuario _user)
        {
            InitializeComponent();
            this.user = _user;
            btnBorrarRol.Visible = false;
            btnModificar.Visible = false;
        }

        private void HomeRol_Load(object sender, EventArgs e)
        {
            this.cargarDatos();
        }

        public void cargarDatos()
        {
            dgvRoles.DataSource = rolDao.listarDatos();
        }

        private void dgvRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int linea = int.Parse(dgvRoles.Rows[e.RowIndex].Cells["id"].Value.ToString());
            dgvFuncionalidades.DataSource = rolDao.getFuncionalidades(linea);
            Rol rol = rolDao.getRolxID(linea);
            if (rol.id == user.rolActivo.id)
            {
                btnBorrarRol.Visible = false;
                btnModificar.Visible = false;
            }
            else
            {
                btnBorrarRol.Visible = true;
                btnModificar.Visible = true;
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            new Alta(this).ShowDialog();
            this.cargarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvRoles.RowCount != 0)
            {
                Rol rol_seleccionado = this.get_rol_seleccionado();
                Modificacion pantalla = new Modificacion(rol_seleccionado);
                pantalla.Owner = this;
                pantalla.ShowDialog();
                this.cargarDatos();
            }
            else
            {
                MessageBox.Show("Seleccione un Rol");
            }
        }

        private Rol get_rol_seleccionado()
        {
            int rol_id = int.Parse(dgvRoles.SelectedCells[0].Value.ToString());
            string rol_nombre = dgvRoles.SelectedCells[1].Value.ToString();
            bool rol_habilitado = bool.Parse(dgvRoles.SelectedCells[2].Value.ToString());

            Rol rol_seleccionado = new Rol(rol_id, rol_nombre);
            rol_seleccionado.activo = rol_habilitado;
            return rol_seleccionado;
        }

        private void btnBorrarRol_Click(object sender, EventArgs e)
        {
            if (dgvRoles.RowCount != 0)
            {
                string mensaje;
                Rol rol_seleccionado = this.get_rol_seleccionado();

                if (rol_seleccionado.activo)
                {
                    mensaje = "¿Está ud. seguro de querer deshabilitar el Rol: " + rol_seleccionado.nombre + "? (Se perderán todos los usuarios asociados)";
                }
                else
                {
                    mensaje = "¿Está ud. seguro de querer habilitar el Rol: " + rol_seleccionado.nombre + "?";
                }

                if (MessageBox.Show(mensaje, "ABM Rol", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) //si selecciona que si
                {
                    if (rol_seleccionado.activo) //si el rol del login es igual al rol que quiere deshabilitar
                    {
                        MessageBox.Show("Operacion exitosa");
                        rolDao.borrar_rol(rol_seleccionado);
                        this.cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("Operacion exitosa");
                        rolDao.activar_rol(rol_seleccionado);
                        this.cargarDatos();
                    }

                }

            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }
    }
}
