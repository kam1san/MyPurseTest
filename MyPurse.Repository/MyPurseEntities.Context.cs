﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyPurse.Repository
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MyPurseEntitiesContainer : DbContext
    {
        public MyPurseEntitiesContainer()
            : base("name=MyPurseEntitiesContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<trans_type> trans_type { get; set; }
        public virtual DbSet<transaction> transactions { get; set; }
    }
}
