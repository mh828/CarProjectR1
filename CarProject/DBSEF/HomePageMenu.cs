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
    
    public partial class HomePageMenu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HomePageMenu()
        {
            this.HomePageMenu1 = new HashSet<HomePageMenu>();
        }
    
        public int HomePageMenuId { get; set; }
        public string Subject { get; set; }
        public string Title { get; set; }
        public string Target { get; set; }
        public Nullable<int> RootHomePageMenuId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HomePageMenu> HomePageMenu1 { get; set; }
        public virtual HomePageMenu HomePageMenu2 { get; set; }
    }
}
