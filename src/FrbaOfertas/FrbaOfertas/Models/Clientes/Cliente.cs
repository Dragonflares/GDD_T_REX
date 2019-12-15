using FrbaOfertas.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Models.Clientes
{
    public class Cliente
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public string tipoDocumento { get; set; }
        public int nroDocumento { get; set; }
        public int telefono { get; set; }
        public Direccion direccion { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public Boolean estado { get; set; } //Baja_logica
        public decimal credito { get; set; }
        public Usuario usuario { get; set; }

        public Cliente() { }

        public Cliente(string nombress, string apellidos, string mails, string tipoDoc, int nroDoc
            , int telefonos, Direccion direccionCli, DateTime fechaNac)
        {
            this.nombres = nombress;
            this.apellido = apellidos;
            this.mail = mails;
            this.tipoDocumento = tipoDoc;
            this.nroDocumento = nroDoc;
            this.telefono = telefonos;
            this.direccion = direccionCli;
            this.fechaNacimiento = fechaNac;
        }
    }
}
