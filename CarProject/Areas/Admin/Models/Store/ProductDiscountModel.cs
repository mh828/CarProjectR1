﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using CarProject.App_extension;
using Microsoft.Ajax.Utilities;

namespace CarProject.Areas.Admin.Models.Store
{
    public class ProductDiscountModel : IValidatableObject
    {
        public DBSEF.CarAutomationEntities dbs = new DBSEF.CarAutomationEntities();

        public DBSEF.Discount Discount { get; set; }
        public List<int> Products { get; set; }
        public List<int> Services { get; set; }
        public List<int> ServicesPack { get; set; }

        public ProductDiscountModel()
        {
            Discount = new DBSEF.Discount();
            Products = new List<int>();
            Services = new List<int>();
            ServicesPack = new List<int>();
        }

        public ProductDiscountModel(int? DiscountId)
        {
            Discount = dbs.Discounts.FirstOrDefault(c => c.DiscountId == DiscountId);
            if (dbs.ProductDiscounts.FirstOrDefault(pd => pd.DiscountId == DiscountId && pd.ProductId != null) != null)
            {
                Products = dbs.ProductDiscounts.Where(pd => pd.DiscountId == DiscountId && pd.ProductId != null)
                    .Select(pd => pd.ProductId.Value)
                    .ToList();
                if (Products == null)
                    Products = new List<int>();
            }
            if (dbs.ProductDiscounts.FirstOrDefault(pd => pd.DiscountId == DiscountId && pd.AutoServiceId != null) != null)
            {
                Services = dbs.ProductDiscounts.Where(pd => pd.DiscountId == DiscountId && pd.AutoServiceId != null)
                    .Select(pd => pd.AutoServiceId.Value)
                    .ToList();
                if (Services == null)
                    Services = new List<int>();
            }
            if (dbs.ProductDiscounts.FirstOrDefault(pd => pd.DiscountId == DiscountId && pd.AutoServicePackId != null) != null)
            {
                ServicesPack = dbs.ProductDiscounts.Where(pd => pd.DiscountId == DiscountId && pd.AutoServicePackId != null)
                    .Select(pd => pd.AutoServicePackId.Value)
                    .ToList();
                if (ServicesPack == null)
                    ServicesPack = new List<int>();
            }
        }

        public void Save()
        {
            dbs.Discounts.Add(this.Discount);

            if (Products != null)
            {
                foreach (var item in Products)
                {
                    var pr = dbs.Products.FirstOrDefault(p => p.ProductId == item);
                    if (pr != null)
                        dbs.ProductDiscounts.Add(new DBSEF.ProductDiscount { Product = pr, Discount = this.Discount });
                }
            }
            if (Services != null)
            {
                foreach (var item in Services)
                {
                    var pr = dbs.AutoServices.FirstOrDefault(p => p.AutoServiceId == item);
                    if (pr != null)
                    {
                        dbs.ProductDiscounts.Add(
                            new DBSEF.ProductDiscount { AutoService = pr, Discount = this.Discount });
                    }
                }
            }

            if (ServicesPack != null)
            {
                foreach (var item in ServicesPack)
                {
                    var pr = dbs.AutoServicePacks.FirstOrDefault(p => p.AutoServicePackId == item);
                    if (pr != null)
                    {
                        dbs.ProductDiscounts.Add(
                            new DBSEF.ProductDiscount { AutoServicePack = pr, Discount = this.Discount });
                    }
                }
            }

            dbs.SaveChanges();
        }

        public void Update()
        {
            if (dbs.ProductDiscounts
                .Any(pdis => pdis.DiscountId == this.Discount.DiscountId &&
                                                   (!Products.Contains(pdis.ProductId.Value))))
            {
                var todeleteproduct =
                    dbs.ProductDiscounts.Where(pdis => pdis.DiscountId == this.Discount.DiscountId &&
                                                       (!Products.Contains(pdis.ProductId.Value)));
                if (todeleteproduct.Any())
                    dbs.ProductDiscounts.RemoveRange(todeleteproduct);
            }
            if (dbs.ProductDiscounts
                .Any(pdis => pdis.DiscountId == this.Discount.DiscountId &&
                                                   (!Services.Contains(pdis.AutoServiceId.Value))))
            {
                var todeleteServices =
                    dbs.ProductDiscounts.Where(pdis => pdis.DiscountId == this.Discount.DiscountId &&
                                                       (!Services.Contains(pdis.AutoServiceId.Value)));
                if (todeleteServices.Any())
                    dbs.ProductDiscounts.RemoveRange(todeleteServices);
            }
            if (dbs.ProductDiscounts
                .Any(pdis => pdis.DiscountId == this.Discount.DiscountId &&
                                                   (!Services.Contains(pdis.AutoServiceId.Value))))
            {
                var todeleteServicesPack =
                    dbs.ProductDiscounts.Where(pdis => pdis.DiscountId == this.Discount.DiscountId &&
                                                       (!ServicesPack.Contains(pdis.AutoServicePackId.Value)));
                if (todeleteServicesPack.Any())
                    dbs.ProductDiscounts.RemoveRange(todeleteServicesPack);

            }

            //var todelete = dbs.ProductDiscounts.Where(pdis => pdis.DiscountId == this.Discount.DiscountId && (!Products.Contains(pdis.ProductId.Value) || !Services.Contains(pdis.AutoServiceId.Value) || !ServicesPack.Contains(pdis.AutoServicePackId.Value)));
            // todelete.



            if (dbs.ProductDiscounts.Any(p => p.DiscountId == this.Discount.DiscountId && p.ProductId != null))
            {
                var listOftProductInDatabase = dbs.ProductDiscounts.Where(pdis => pdis.DiscountId == this.Discount.DiscountId).Select(pdis => pdis.ProductId.Value).ToList();

            }
            if (dbs.ProductDiscounts.Any(p => p.DiscountId == this.Discount.DiscountId && p.AutoServiceId != null))
            {
                var listOftServoceInDatabase = dbs.ProductDiscounts.Where(pdis => pdis.DiscountId == this.Discount.DiscountId).Select(pdis => pdis.AutoServiceId.Value).ToList();

            }
            if (dbs.ProductDiscounts.Any(p => p.DiscountId == this.Discount.DiscountId && p.AutoServicePackId != null))
            {
                var listOftServicePackInDatabase = dbs.ProductDiscounts.Where(pdis => pdis.DiscountId == this.Discount.DiscountId).Select(pdis => pdis.AutoServicePackId.Value).ToList();

            }

            if (Products != null && Products.Count > 0)
            {
                foreach (var item in Products)
                {
                    var pr = dbs.Products.FirstOrDefault(p => p.ProductId == item);
                    if (pr != null)
                        dbs.ProductDiscounts.Add(new DBSEF.ProductDiscount { Product = pr, Discount = this.Discount });
                }
            }
            if (Services != null && Services.Count > 0)
            {
                foreach (var item in Services)
                {
                    var pr = dbs.AutoServices.FirstOrDefault(p => p.AutoServiceId == item);
                    if (pr != null)
                        dbs.ProductDiscounts.Add(new DBSEF.ProductDiscount { AutoService = pr, Discount = this.Discount });
                }
            }
            if (ServicesPack != null && ServicesPack.Count > 0)
            {
                foreach (var item in ServicesPack)
                {
                    var pr = dbs.AutoServicePacks.FirstOrDefault(p => p.AutoServicePackId == item);
                    if (pr != null)
                        dbs.ProductDiscounts.Add(new DBSEF.ProductDiscount { AutoServicePack = pr, Discount = this.Discount });
                }
            }

            if (dbs.ProductDiscounts.Any(p => p.DiscountId == this.Discount.DiscountId && p.ProductId != null))
            {
                var listOftProductInDatabase = dbs.ProductDiscounts.Where(pdis => pdis.DiscountId == this.Discount.DiscountId).Select(pdis => pdis.ProductId.Value).ToList();
                var insertIds = Products.Where(p => !listOftProductInDatabase.Contains(p));

                foreach (var item in insertIds)
                {
                    var pr = dbs.Products.FirstOrDefault(p => p.ProductId == item);
                    if (pr != null)
                        dbs.ProductDiscounts.Add(new DBSEF.ProductDiscount { Product = pr, Discount = this.Discount });
                }
            }

            if (dbs.ProductDiscounts.Any(p => p.DiscountId == this.Discount.DiscountId && p.AutoServiceId != null))
            {
                var listOftServoceInDatabase = dbs.ProductDiscounts.Where(pdis => pdis.DiscountId == this.Discount.DiscountId).Select(pdis => pdis.AutoServiceId.Value).ToList();
                var insertSIds = Services.Where(p => !listOftServoceInDatabase.Contains(p));

                foreach (var item in insertSIds)
                {
                    var pr = dbs.AutoServices.FirstOrDefault(p => p.AutoServiceId == item);
                    if (pr != null)
                        dbs.ProductDiscounts.Add(new DBSEF.ProductDiscount { AutoService = pr, Discount = this.Discount });
                }
            }

            if (dbs.ProductDiscounts.Any(p => p.DiscountId == this.Discount.DiscountId && p.AutoServicePackId != null))

            {
                var listOftServicePackInDatabase = dbs.ProductDiscounts.Where(pdis => pdis.DiscountId == this.Discount.DiscountId).Select(pdis => pdis.AutoServicePackId.Value).ToList();
                var insertSPIds = ServicesPack.Where(p => !listOftServicePackInDatabase.Contains(p));

                foreach (var item in insertSPIds)
                {
                    var pr = dbs.AutoServicePacks.FirstOrDefault(p => p.AutoServicePackId == item);
                    if (pr != null)
                        dbs.ProductDiscounts.Add(new DBSEF.ProductDiscount { AutoServicePack = pr, Discount = this.Discount });
                }
            }
            

            dbs.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var res = new List<ValidationResult>();
            if (StringAddRoutes.IsNullOrWhiteSpace(Discount.DiscountCode))
                res.Add(new ValidationResult("کد تخفیف وارد نشد است", new string[] { "Discount.DiscountCode" }));
            else if (dbs.Discounts.Count(dis => dis.DiscountCode == this.Discount.DiscountCode) > 0)
                res.Add(new ValidationResult("کد تخفیف وارد شده تکراری است", new string[] { "Discount.DiscountCode" }));

            if (StringAddRoutes.IsNullOrWhiteSpace(Discount.Discount1))
                res.Add(new ValidationResult("درصد تخفیف وارد نشده است", new string[] { "Discount.Discount1" }));
            else if (!Discount.Discount1.IsFloat())
                res.Add(new ValidationResult("مقدار وارد شده صحیح نیست", new string[] { "Discount.Discount1" }));
            //if (Products.Count == 0)
            //    res.Add(new ValidationResult("محصولات شامل تخفیف تعیین نشده اند", new string[] { "Products" }));
            return res;
        }
    }
}