﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PaperEntities : DbContext
    {
        public PaperEntities()
            : base("name=PaperEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<aspnet_Roles> aspnet_Roles { get; set; }
        public DbSet<aspnet_Users> aspnet_Users { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<CostoPublicacion> CostoPublicacion { get; set; }
        public DbSet<Distribuidor> Distribuidor { get; set; }
        public DbSet<DistribuidorCuenta> DistribuidorCuenta { get; set; }
        public DbSet<DistribuidorKiosco> DistribuidorKiosco { get; set; }
        public DbSet<Editorial> Editorial { get; set; }
        public DbSet<Feriado> Feriado { get; set; }
        public DbSet<Kiosco> Kiosco { get; set; }
        public DbSet<KioscoUsuario> KioscoUsuario { get; set; }
        public DbSet<MovimientosDiarios> MovimientosDiarios { get; set; }
        public DbSet<PrecioVenta> PrecioVenta { get; set; }
        public DbSet<Publicacion> Publicacion { get; set; }
        public DbSet<RoleAction> RoleAction { get; set; }
        public DbSet<Subscripcion> Subscripcion { get; set; }
    }
}
