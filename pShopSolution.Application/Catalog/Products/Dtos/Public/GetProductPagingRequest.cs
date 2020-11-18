using pShopSolution.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace pShopSolution.Application.Catalog.Products.Dtos.Public
{
    public class GetProductPagingRequest:PagingRequestBase
    {
        public int CategoryID { get; set; }
    }
}
