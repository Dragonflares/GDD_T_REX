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

namespace FrbaOfertas.ABMRol
{
    public partial class ABMRol : Form
    {
        public PantallaPrincipal form_anterior { get; set; }
        RolDAO rolDao = new RolDAO();
        public ABMRol(PantallaPrincipal pantalla)
        {
            InitializeComponent();
            form_anterior = pantalla;
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
            int i = int.Parse(dgvRoles.SelectedCells[0].Value.ToString());
            dgvFuncionalidades.DataSource = rolDao.getFuncionalidades(i);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            new Alta(this).ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvRoles.RowCount != 0)
            {
                Rol rol_seleccionado = this.get_rol_seleccionado();
                new Modificacion(rol_seleccionado).ShowDialog();
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
                    if (UsuarioDAO.tieneRol(form_anterior.username, rol_seleccionado.id)) //si el rol del login es igual al rol que quiere deshabilitar
                    {
                        if (MessageBox.Show("¿Está a punto de inhabilitar el Rol en el que se encuentra logueado, se cerrará la sesión al finalizar, desea continuar?", "ABM Rol", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            rolDao.borrar_rol(rol_seleccionado);
                            Application.Exit();
                            Application.Restart();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Operacion exitosa");
                        rolDao.borrar_rol(rol_seleccionado);
                        this.cargarDatos();
                    }

                }

            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
