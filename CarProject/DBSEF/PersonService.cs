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
    
    public partial class PersonService
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PersonService()
        {
            this.ProductServiceUses = new HashSet<ProductServiceUse>();
        }
    
        public int PersonServicesId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> ServicesId { get; set; }
        public Nullable<int> ServicesCurrentEntity { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
    
        public virtual AutoService AutoService { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductServiceUse> ProductServiceUses { get; set; }
    }
}
