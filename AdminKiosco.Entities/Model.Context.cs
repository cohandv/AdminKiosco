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
    
        public DbSet<aspnet_Applications> aspnet_Applications { get; set; }
        public DbSet<aspnet_Membership> aspnet_Membership { get; set; }
        public DbSet<aspnet_Paths> aspnet_Paths { get; set; }
        public DbSet<aspnet_PersonalizationAllUsers> aspnet_PersonalizationAllUsers { get; set; }
        public DbSet<aspnet_PersonalizationPerUser> aspnet_PersonalizationPerUser { get; set; }
        public DbSet<aspnet_Profile> aspnet_Profile { get; set; }
        public DbSet<aspnet_Roles> aspnet_Roles { get; set; }
        public DbSet<aspnet_SchemaVersions> aspnet_SchemaVersions { get; set; }
        public DbSet<aspnet_Users> aspnet_Users { get; set; }
        public DbSet<aspnet_WebEvent_Events> aspnet_WebEvent_Events { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Distribuidor> Distribuidor { get; set; }
        public DbSet<Kiosco> Kiosco { get; set; }
        public DbSet<Precio> Precio { get; set; }
        public DbSet<Promocion> Promocion { get; set; }
        public DbSet<Publicacion> Publicacion { get; set; }
        public DbSet<RoleAction> RoleAction { get; set; }
        public DbSet<Subscripcion> Subscripcion { get; set; }
        public DbSet<TipoPublicacion> TipoPublicacion { get; set; }
        public DbSet<UsersOpenAuthAccounts> UsersOpenAuthAccounts { get; set; }
        public DbSet<UsersOpenAuthData> UsersOpenAuthData { get; set; }
    }
}
