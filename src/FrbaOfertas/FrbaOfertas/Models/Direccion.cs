using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Models
{
    public class Direccion
    {
        public int id { get; set; }
        public string calle { get; set; }
        public string piso { get; set; }
        public string codigopostal { get; set; }
        public string localidad { get; set; }
        public string departamento { get; set; }

        public Direccion(int id, string _calle, string _piso, string CP, string _localidad, string depto)
        {
            this.id = id;
            this.calle = _calle;
            this.piso = _piso;
            this.codigopostal = CP;
            this.localidad = _localidad;
            this.departamento = depto;
        }

        override public string ToString()
        {
            return this.calle + ", "+ this.localidad;
        }
    }
}
