﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SEProject.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SEEntities : DbContext
    {
        public SEEntities()
            : base("name=SEEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<DOES_BUSINESS_IN> DOES_BUSINESS_IN { get; set; }
        public virtual DbSet<EMPLOYEE> EMPLOYEE { get; set; }
        public virtual DbSet<HAS_SKILL> HAS_SKILL { get; set; }
        public virtual DbSet<ORDER> ORDER { get; set; }
        public virtual DbSet<Order_Line> Order_Line { get; set; }
        public virtual DbSet<PRODUCED_IN> PRODUCED_IN { get; set; }
        public virtual DbSet<PRODUCT> PRODUCT { get; set; }
        public virtual DbSet<PRODUCT_LINE> PRODUCT_LINE { get; set; }
        public virtual DbSet<RAW_MATERIAL> RAW_MATERIAL { get; set; }
        public virtual DbSet<SALES_PERSON> SALES_PERSON { get; set; }
        public virtual DbSet<SALES_TERRITORY> SALES_TERRITORY { get; set; }
        public virtual DbSet<SKILL> SKILL { get; set; }
        public virtual DbSet<SUPERVISOR> SUPERVISOR { get; set; }
        public virtual DbSet<SUPPLIES> SUPPLIES { get; set; }
        public virtual DbSet<USES> USES { get; set; }
        public virtual DbSet<VENDOR> VENDOR { get; set; }
        public virtual DbSet<WORK_CENTER> WORK_CENTER { get; set; }
        public virtual DbSet<WORKS_IN> WORKS_IN { get; set; }
    }
}
