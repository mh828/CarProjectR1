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
    
    public partial class ContentsCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContentsCategory()
        {
            this.Contents = new HashSet<Content>();
            this.ContentsCategory1 = new HashSet<ContentsCategory>();
        }
    
        public int ContentsCategoryId { get; set; }
        public string Name { get; set; }
        public string Describe { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string EnglishName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Content> Contents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContentsCategory> ContentsCategory1 { get; set; }
        public virtual ContentsCategory ContentsCategory2 { get; set; }
    }
}
