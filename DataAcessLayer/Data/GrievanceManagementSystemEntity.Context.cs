﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GMS.DataAcessLayer.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GrievanceManagementSystemEntities : DbContext
    {
        public GrievanceManagementSystemEntities()
            : base("name=GrievanceManagementSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<GrievanceDepartmentMaster> GrievanceDepartmentMasters { get; set; }
        public virtual DbSet<GrievanceDetail> GrievanceDetails { get; set; }
        public virtual DbSet<GrievancePriorityMaster> GrievancePriorityMasters { get; set; }
        public virtual DbSet<GrievanceRoleMaster> GrievanceRoleMasters { get; set; }
        public virtual DbSet<GrievanceSendToMaster> GrievanceSendToMasters { get; set; }
        public virtual DbSet<GrievanceStatusMaster> GrievanceStatusMasters { get; set; }
        public virtual DbSet<GrievanceTypeMaster> GrievanceTypeMasters { get; set; }
        public virtual DbSet<GrievanceMaster> GrievanceMasters { get; set; }
        public virtual DbSet<GrievanceUserDetail> GrievanceUserDetails { get; set; }
    }
}