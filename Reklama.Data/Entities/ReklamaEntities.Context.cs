﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Reklama.Data.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ReklamaCustomEntities : DbContext
    {
        public ReklamaCustomEntities()
            : base("name=ReklamaCustomEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Banners> Banners { get; set; }
        public virtual DbSet<BannerTypes> BannerTypes { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryParameter> CategoryParameter { get; set; }
        public virtual DbSet<CategoryParametersSection> CategoryParametersSection { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductBookmark> ProductBookmark { get; set; }
        public virtual DbSet<ProductFeedback> ProductFeedback { get; set; }
        public virtual DbSet<ProductImage> ProductImage { get; set; }
        public virtual DbSet<ProductParameterValue> ProductParameterValue { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<ShopFeedback> ShopFeedback { get; set; }
        public virtual DbSet<ShopProduct> ShopProduct { get; set; }
        public virtual DbSet<ShopProductStatus> ShopProductStatus { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
    }
}
