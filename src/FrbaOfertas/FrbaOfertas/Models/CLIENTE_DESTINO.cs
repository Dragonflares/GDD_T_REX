//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FrbaOfertas.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CLIENTE_DESTINO
    {
        public CLIENTE_DESTINO()
        {
            this.CUPON = new HashSet<CUPON>();
        }
    
        public int id_consumidor { get; set; }
        public string dest_nombre { get; set; }
        public string dest_apellido { get; set; }
        public decimal dest_nrodocumento { get; set; }
        public string dest_tipo_documento { get; set; }
        public System.DateTime dest_fecha_nacimiento { get; set; }
        public string dest_mail { get; set; }
        public int dest_telefono { get; set; }
        public int id_domicilio { get; set; }
    
        public virtual DOMICILIO DOMICILIO { get; set; }
        public virtual ICollection<CUPON> CUPON { get; set; }
    }
}
