﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PI_12_BO.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class pi_12Entities : DbContext
    {
        public pi_12Entities()
            : base("name=pi_12Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Ingrediente> Ingrediente { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<Encomenda> Encomenda { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Encomenda_Produto_Ingrediente> Encomenda_Produto_Ingrediente { get; set; }
        public virtual DbSet<Classe> Classe { get; set; }
        public virtual DbSet<Encomenda_Menu_Produto> Encomenda_Menu_Produto { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Menu_Produto> Menu_Produto { get; set; }
        public virtual DbSet<Produto_Ingrediente> Produto_Ingrediente { get; set; }
    }
}