using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.ComprarOferta
{
    public partial class ListadoClientes : Form
    {
        private ComprarOferta pantalla_Ant;
        public ListadoClientes(ComprarOferta pantalla)
        {
            pantalla_Ant = pantalla;
            InitializeComponent();
        }
    }
}
