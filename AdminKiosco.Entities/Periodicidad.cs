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
    
    public partial class Periodicidad
    {
        public Periodicidad()
        {
            this.Cliente = new HashSet<Cliente>();
            this.Publicacion = new HashSet<Publicacion>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Dias { get; set; }
    
        public virtual ICollection<Cliente> Cliente { get; set; }
        public virtual ICollection<Publicacion> Publicacion { get; set; }
    }
}