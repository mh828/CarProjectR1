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
    
    public partial class CarsReview
    {
        public int CarsReviewId { get; set; }
        public Nullable<int> CarsId { get; set; }
        public string Review { get; set; }
        public Nullable<double> CarScore { get; set; }
        public Nullable<double> Beauty { get; set; }
        public Nullable<double> WorthBuying { get; set; }
        public Nullable<double> Quality { get; set; }
        public Nullable<double> Services { get; set; }
    
        public virtual Car Car { get; set; }
    }
}
