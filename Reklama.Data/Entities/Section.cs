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
    
    public partial class Section
    {
        public Section()
        {
            this.Announcement = new HashSet<Announcement>();
            this.AnnouncementsPremiumsRef = new HashSet<AnnouncementsPremiumsRef>();
            this.Subsection = new HashSet<Subsection>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Announcement> Announcement { get; set; }
        public virtual ICollection<AnnouncementsPremiumsRef> AnnouncementsPremiumsRef { get; set; }
        public virtual ICollection<Subsection> Subsection { get; set; }
    }
}
