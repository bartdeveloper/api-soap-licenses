﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API_SOAP_licenses
{
    using API_SOAP_licenses.Repository;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class API_LicenseEntities : DbContext, IRepositoryContext
    {
        public API_LicenseEntities()
            : base("name=API_LicenseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual IDbSet<company> companies { get; set; }
        public virtual IDbSet<license> licenses { get; set; }
        public virtual IDbSet<version> versions { get; set; }
    }
}
