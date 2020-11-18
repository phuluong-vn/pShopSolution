﻿using pShopSolution.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.Application.Catalog.Products.Dtos.Manage
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string Keywork { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
