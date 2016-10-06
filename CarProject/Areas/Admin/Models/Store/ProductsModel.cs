﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CarProject.App_extension;

namespace CarProject.Areas.Admin.Models.Store
{
    public class ProductsModel : IValidatableObject
    {
        public DBSEF.CarAutomationEntities dbs = new DBSEF.CarAutomationEntities();

        public DBSEF.Product Product { get; set; }

        public bool IsNull { get; set; }

        [AllowHtml]
        public string HtmlReview { get; set; }

        public ProductsModel()
        {
            Product = new DBSEF.Product();
            Product.ProductReview = new DBSEF.ProductReview();
            IsNull = true;
        }

        public ProductsModel(int? id)
        {
            Product = dbs.Products.FirstOrDefault(p => p.ProductId == id);
            if (Product == null)
            {
                IsNull = true;
                Product = new DBSEF.Product();
            }
            else
                IsNull = false;
            
            if (Product.ProductReview == null && Product.ProductReviewId != null && Product.ProductReviewId > 0)
            {
                Product.ProductReview = dbs.ProductReviews.FirstOrDefault(r => r.ProductReviewId == Product.ProductReviewId);
            }
        }


        public void Save()
        {
            dbs.Products.Add(this.Product);
            dbs.SaveChanges();
        }

        public void Save_review()
        {
            var x = new DBSEF.ProductReview { ProductReview1 = HtmlReview };
            dbs.ProductReviews.Add(x);

            Product.ProductReview = x;
            dbs.SaveChanges();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();
            if (Product.ProductName.IsNullOrWhiteSpace())
                result.Add(new ValidationResult("نام محصول وارد نشده است", new string[] { "Product.ProductName" }));
            if (Product.CategoryId == null)
                result.Add(new ValidationResult("گروه تعیین نشده است", new string[] { "Product.CategoryId" }));
            return result;
        }
    }
}