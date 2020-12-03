﻿using System;
using System.Collections.Generic;

namespace PShopSolution.ViewModels.Catalog.Products
{
    public class ProductVm
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Stock { get; set; }
        public DateTime DateCreate { get; set; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public int ViewCount { get; set; }
        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }
        public bool? IsFeature { get; set; }
        public IList<string> Categories { get; set; }
    }
}