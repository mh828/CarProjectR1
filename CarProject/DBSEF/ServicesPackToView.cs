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
    
    public partial class ServicesPackToView
    {
        public int ServicesPackToViewId { get; set; }
        public Nullable<int> Viewd { get; set; }
        public Nullable<int> ServicesPackId { get; set; }
        public Nullable<int> Favorite { get; set; }
    
        public virtual AutoServicePack AutoServicePack { get; set; }
    }
}
