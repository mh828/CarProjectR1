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
    
    public partial class Person
    {
        public int PersonId { get; set; }
        public string PersonFirtstName { get; set; }
        public string PersonLastName { get; set; }
        public string PersonPhone { get; set; }
        public string PersonMobile { get; set; }
        public string PersonEmail { get; set; }
        public string PersonAddressCity { get; set; }
        public string PersonAddress { get; set; }
        public Nullable<int> UserId { get; set; }
    
        public virtual User User { get; set; }
    }
}
