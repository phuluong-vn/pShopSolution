﻿using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.Data.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImgaPath { get; set; }
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public DateTime DateCreate { get; set; }
        public int SortOrder { get; set; }
        public int FileSize { get; set; }
        public Product Product { get; set; }
    }
}
