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
    
    public partial class DetailedBrakeSystem
    {
        public int DetailedBrakeSystemId { get; set; }
        public string DetailedName { get; set; }
        public Nullable<bool> HaveDetailed { get; set; }
        public Nullable<int> CarId { get; set; }
    
        public virtual Car Car { get; set; }
    }
}
