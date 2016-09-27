﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarProject.CLS
{
    public class ServicesSearchModel
    {
        public string[] ProductName { get; set; }
        public string[] BrandName { get; set; }
        public string[] CarmodelName { get; set; }
        public string[] Manufacture { get; set; }
        public string[] Country { get; set; }
        public int PriceFrom { get; set; }
        public int PriceTo { get; set; }
        public string[] CategoryName { get; set; }
    }
}