//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarProject.DBSEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserAutoService
    {
        public int UserAutoServiceId { get; set; }
        public Nullable<int> AutoServiceId { get; set; }
        public Nullable<System.DateTime> AutoServiceAddedDate { get; set; }
        public Nullable<bool> AutoServiceUsed { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<System.DateTime> AutoServiceUsedDate { get; set; }
    
        public virtual AutoService AutoService { get; set; }
        public virtual User User { get; set; }
    }
}
