using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaOfertas.Models.Roles;
using FrbaOfertas.Models.Proveedores;
using FrbaOfertas.Models.Clientes;

namespace FrbaOfertas.Models.Usuarios
{
    public class Usuario
    {
        public int id{ get; set; }
        public string nombre { get; set; }
        public Rol rolActivo { get; set; }
        public Cliente cliente { get; set; }
        public Proveedor proveedor { get; set; }

        public Usuario(int _id, string username, Rol rol, Cliente cli, Proveedor prov)
        {
            this.id = _id;
            this.nombre = username;
            this.rolActivo = rol;
            this.cliente = cli;
            this.proveedor = prov;
        }
    }
}
