﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookApplication.Models.Entitiy
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MvcDbLibraryEntities : DbContext
    {
        public MvcDbLibraryEntities()
            : base("name=MvcDbLibraryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TBLAUTHOR> TBLAUTHOR { get; set; }
        public virtual DbSet<TBLBOOKS> TBLBOOKS { get; set; }
        public virtual DbSet<TBLCATEGORIES> TBLCATEGORIES { get; set; }
    }
}
