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
    
    public partial class Promocion
    {
        public Promocion()
        {
            this.Subscripcion = new HashSet<Subscripcion>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int PublicacionId { get; set; }
        public int PrecioId { get; set; }
    
        public virtual Precio Precio { get; set; }
        public virtual Publicacion Publicacion { get; set; }
        public virtual ICollection<Subscripcion> Subscripcion { get; set; }
    }
}
