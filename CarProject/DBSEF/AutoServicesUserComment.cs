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
    
    public partial class AutoServicesUserComment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AutoServicesUserComment()
        {
            this.AutoServicesUserComments1 = new HashSet<AutoServicesUserComment>();
        }
    
        public int AutoServicesUserCommentsId { get; set; }
        public Nullable<int> AutoServicesId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Comment { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
        public Nullable<int> RootAutoServicesUserCommentsId { get; set; }
    
        public virtual AutoService AutoService { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AutoServicesUserComment> AutoServicesUserComments1 { get; set; }
        public virtual AutoServicesUserComment AutoServicesUserComment1 { get; set; }
        public virtual User User { get; set; }
    }
}
