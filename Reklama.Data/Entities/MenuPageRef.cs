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
    
    public partial class MenuPageRef
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public int PageId { get; set; }
        public int Priority { get; set; }
    
        public virtual Menu Menu { get; set; }
        public virtual Page Page { get; set; }
    }
}