//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdminKiosco.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subscripcion
    {
        public int Id { get; set; }
        public System.DateTime FechaCreacion { get; set; }
        public int ClienteId { get; set; }
        public System.DateTime FechaAlta { get; set; }
        public Nullable<System.DateTime> FechaBaja { get; set; }
    
        public virtual Cliente Cliente { get; set; }
    }
}
