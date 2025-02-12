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
    
    public partial class PROVEEDOR
    {
        public PROVEEDOR()
        {
            this.FACTURA_PROVEEDOR = new HashSet<FACTURA_PROVEEDOR>();
            this.OFERTA = new HashSet<OFERTA>();
        }
    
        public int id_proveedor { get; set; }
        public string provee_rs { get; set; }
        public string provee_cuit { get; set; }
        public string email { get; set; }
        public Nullable<int> provee_telefono { get; set; }
        public bool estado { get; set; }
        public int id_domicilio { get; set; }
        public int id_rubro { get; set; }
        public int id_usuario { get; set; }
    
        public virtual DOMICILIO DOMICILIO { get; set; }
        public virtual ICollection<FACTURA_PROVEEDOR> FACTURA_PROVEEDOR { get; set; }
        public virtual ICollection<OFERTA> OFERTA { get; set; }
        public virtual RUBRO RUBRO { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}
