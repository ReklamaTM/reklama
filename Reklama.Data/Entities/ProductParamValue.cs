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
    
    public partial class ProductParamValue
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ParamId { get; set; }
        public string Value { get; set; }
        public Nullable<int> UnitId { get; set; }
        public Nullable<int> ParamSubsectionId { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual ProductParam ProductParam { get; set; }
    }
}
