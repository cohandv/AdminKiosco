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
    
    public partial class Distribuidor
    {
        public Distribuidor()
        {
            this.DistribuidorCuenta = new HashSet<DistribuidorCuenta>();
            this.DistribuidorKiosco = new HashSet<DistribuidorKiosco>();
            this.Editorial = new HashSet<Editorial>();
            this.Publicacion = new HashSet<Publicacion>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
    
        public virtual ICollection<DistribuidorCuenta> DistribuidorCuenta { get; set; }
        public virtual ICollection<DistribuidorKiosco> DistribuidorKiosco { get; set; }
        public virtual ICollection<Editorial> Editorial { get; set; }
        public virtual ICollection<Publicacion> Publicacion { get; set; }
    }
}
