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
    
    public partial class FUNCIONALIDAD_ROL
    {
        public int id_funcionalidad { get; set; }
        public int id_rol { get; set; }
        public bool estado { get; set; }
    
        public virtual FUNCIONALIDAD FUNCIONALIDAD { get; set; }
        public virtual ROL ROL { get; set; }
    }
}
