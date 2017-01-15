﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CarAutomationEntities : DbContext
    {
        public CarAutomationEntities()
            : base("name=CarAutomationEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AirConditioningSystem> AirConditioningSystems { get; set; }
        public virtual DbSet<AirConditioningSystemDetail> AirConditioningSystemDetails { get; set; }
        public virtual DbSet<AutoService> AutoServices { get; set; }
        public virtual DbSet<AutoServiceCar> AutoServiceCars { get; set; }
        public virtual DbSet<AutoServicePack> AutoServicePacks { get; set; }
        public virtual DbSet<AutoService1> AutoServices1 { get; set; }
        public virtual DbSet<BasketItem> BasketItems { get; set; }
        public virtual DbSet<Basket> Baskets { get; set; }
        public virtual DbSet<BrakeSystem> BrakeSystems { get; set; }
        public virtual DbSet<CarAirbag> CarAirbags { get; set; }
        public virtual DbSet<CarAudioSystem> CarAudioSystems { get; set; }
        public virtual DbSet<CarBrand> CarBrands { get; set; }
        public virtual DbSet<CarComment> CarComments { get; set; }
        public virtual DbSet<CarDetail> CarDetails { get; set; }
        public virtual DbSet<CarEngine> CarEngines { get; set; }
        public virtual DbSet<CarGearBox> CarGearBoxes { get; set; }
        public virtual DbSet<CarLightingSystem> CarLightingSystems { get; set; }
        public virtual DbSet<CarModel> CarModels { get; set; }
        public virtual DbSet<CarPhysicalDetail> CarPhysicalDetails { get; set; }
        public virtual DbSet<CarPrice> CarPrices { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarSeatOption> CarSeatOptions { get; set; }
        public virtual DbSet<CarSensorsSystem> CarSensorsSystems { get; set; }
        public virtual DbSet<CarsInSameClass> CarsInSameClasses { get; set; }
        public virtual DbSet<CarsPro> CarsProes { get; set; }
        public virtual DbSet<CarsQnA> CarsQnAs { get; set; }
        public virtual DbSet<CarsReview> CarsReviews { get; set; }
        public virtual DbSet<CarsReviewPoint> CarsReviewPoints { get; set; }
        public virtual DbSet<CarsToView> CarsToViews { get; set; }
        public virtual DbSet<CarUserComment> CarUserComments { get; set; }
        public virtual DbSet<CarWheel> CarWheels { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<ContactUsMessage> ContactUsMessages { get; set; }
        public virtual DbSet<ContentPresentation> ContentPresentations { get; set; }
        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<ContentsCategory> ContentsCategories { get; set; }
        public virtual DbSet<ContentUserComment> ContentUserComments { get; set; }
        public virtual DbSet<ContetComment> ContetComments { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<DaysOfWeek> DaysOfWeeks { get; set; }
        public virtual DbSet<DetailedBrakeSystem> DetailedBrakeSystems { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<FuelConsumption> FuelConsumptions { get; set; }
        public virtual DbSet<GlassAndMirror> GlassAndMirrors { get; set; }
        public virtual DbSet<HomePageMenu> HomePageMenus { get; set; }
        public virtual DbSet<Manufacture> Manufactures { get; set; }
        public virtual DbSet<MarketingMail> MarketingMails { get; set; }
        public virtual DbSet<NewLatterEmail> NewLatterEmails { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonCarDetail> PersonCarDetails { get; set; }
        public virtual DbSet<PersonCar> PersonCars { get; set; }
        public virtual DbSet<PersonProduct> PersonProducts { get; set; }
        public virtual DbSet<PersonProductEntity> PersonProductEntities { get; set; }
        public virtual DbSet<PersonService> PersonServices { get; set; }
        public virtual DbSet<PersonServicesPack> PersonServicesPacks { get; set; }
        public virtual DbSet<PersonServicesUseRequest> PersonServicesUseRequests { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCar> ProductCars { get; set; }
        public virtual DbSet<ProductComment> ProductComments { get; set; }
        public virtual DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public virtual DbSet<ProductInService> ProductInServices { get; set; }
        public virtual DbSet<ProductPrice> ProductPrices { get; set; }
        public virtual DbSet<ProductQnA> ProductQnAs { get; set; }
        public virtual DbSet<ProductReview> ProductReviews { get; set; }
        public virtual DbSet<ProductServicePackUse> ProductServicePackUses { get; set; }
        public virtual DbSet<ProductServiceUse> ProductServiceUses { get; set; }
        public virtual DbSet<ProductsOrServicesDeliveryType> ProductsOrServicesDeliveryTypes { get; set; }
        public virtual DbSet<ProductStore> ProductStores { get; set; }
        public virtual DbSet<ProductToView> ProductToViews { get; set; }
        public virtual DbSet<ProductUserComment> ProductUserComments { get; set; }
        public virtual DbSet<RootCarUserComment> RootCarUserComments { get; set; }
        public virtual DbSet<SecuritySystem> SecuritySystems { get; set; }
        public virtual DbSet<ServicesPackToView> ServicesPackToViews { get; set; }
        public virtual DbSet<ServiceToView> ServiceToViews { get; set; }
        public virtual DbSet<SlideShow> SlideShows { get; set; }
        public virtual DbSet<SteeringSystem> SteeringSystems { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TimeOfDay> TimeOfDays { get; set; }
        public virtual DbSet<TodaysSpecial> TodaysSpecials { get; set; }
        public virtual DbSet<Troubleshooting> Troubleshootings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
    }
}
