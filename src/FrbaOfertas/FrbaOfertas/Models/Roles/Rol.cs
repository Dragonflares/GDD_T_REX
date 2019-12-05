using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Models.Roles
{
    public class Rol
    {
        
        public int id { get;  set;}
        public String nombre { get; set;}
        public bool activo { get; set;}

        public Rol (int id, String nombre) 
        {
            this.id = id;
            this.nombre = nombre;
            this.activo = true;
        }
    }
}
