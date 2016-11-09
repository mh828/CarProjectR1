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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.PersonProducts = new HashSet<PersonProduct>();
            this.ProductCars = new HashSet<ProductCar>();
            this.ProductComments = new HashSet<ProductComment>();
            this.ProductDiscounts = new HashSet<ProductDiscount>();
            this.ProductInServices = new HashSet<ProductInService>();
            this.ProductPrices = new HashSet<ProductPrice>();
            this.ProductStores = new HashSet<ProductStore>();
            this.ProductToViews = new HashSet<ProductToView>();
            this.ToBaskets = new HashSet<ToBasket>();
            this.TodaysSpecials = new HashSet<TodaysSpecial>();
            this.Troubleshootings = new HashSet<Troubleshooting>();
        }
    
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> CarId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<double> ProductHeight { get; set; }
        public Nullable<double> ProductWidth { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<double> ProductWeight { get; set; }
        public Nullable<double> ProductLength { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> ManufactureId { get; set; }
        public string ProductSecription { get; set; }
        public Nullable<int> PartNumber { get; set; }
        public string MetaTags { get; set; }
        public Nullable<double> ProductRating { get; set; }
        public Nullable<int> ProductReviewId { get; set; }
        public Nullable<int> ProductQnAId { get; set; }
        public Nullable<int> DiscountId { get; set; }
        public Nullable<bool> WithInstall { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual Category Category { get; set; }
        public virtual Company Company { get; set; }
        public virtual Country Country { get; set; }
        public virtual Manufacture Manufacture { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonProduct> PersonProducts { get; set; }
        public virtual ProductQnA ProductQnA { get; set; }
        public virtual ProductReview ProductReview { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductCar> ProductCars { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductComment> ProductComments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductDiscount> ProductDiscounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductInService> ProductInServices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductPrice> ProductPrices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductStore> ProductStores { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductToView> ProductToViews { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ToBasket> ToBaskets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TodaysSpecial> TodaysSpecials { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Troubleshooting> Troubleshootings { get; set; }
    }
}
