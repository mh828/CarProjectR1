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
    
    public partial class ProductStore
    {
        public int ProductStoreId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> ProductEntity { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
