using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Models.Funcionalidades
{
    public class Funcionalidad
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public int rol_id { get; set; }

       public Funcionalidad (int id, String nombre,int rol_id)
       {
           this.id = id;
           this.nombre = nombre;
           this.rol_id = rol_id;
       }

       public Funcionalidad(int id, String nombre)
       {
           this.id = id;
           this.nombre = nombre;
       }

       public override string ToString()
       {
           return nombre;
       }
    }
}
