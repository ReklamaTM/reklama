//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class CatalogCategory
    {
        public CatalogCategory()
        {
            this.CatalogSecondCategory = new HashSet<CatalogSecondCategory>();
            this.Product = new HashSet<Product>();
            this.ProductSectionParamRef = new HashSet<ProductSectionParamRef>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<CatalogSecondCategory> CatalogSecondCategory { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<ProductSectionParamRef> ProductSectionParamRef { get; set; }
    }
}
