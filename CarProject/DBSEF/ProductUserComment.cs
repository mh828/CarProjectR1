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
    
    public partial class ProductUserComment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductUserComment()
        {
            this.ProductUserComments1 = new HashSet<ProductUserComment>();
        }
    
        public int ProductUserCommentsId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Comment { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
        public Nullable<int> RootProductUserCommentsId { get; set; }
    
        public virtual Product Product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductUserComment> ProductUserComments1 { get; set; }
        public virtual ProductUserComment ProductUserComment1 { get; set; }
        public virtual User User { get; set; }
    }
}
