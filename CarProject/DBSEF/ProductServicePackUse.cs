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
    
    public partial class ProductServicePackUse
    {
        public int ProductServicePackUseId { get; set; }
        public Nullable<int> PersonServicesPackId { get; set; }
        public Nullable<System.DateTime> DateUsed { get; set; }
        public Nullable<int> EntityUsed { get; set; }
    
        public virtual PersonServicesPack PersonServicesPack { get; set; }
    }
}
