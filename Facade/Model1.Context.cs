﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Facade
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CustomerManagementDBEntities : DbContext
    {
        public CustomerManagementDBEntities()
            : base("name=CustomerManagementDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<AdminLogin> AdminLogin { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
