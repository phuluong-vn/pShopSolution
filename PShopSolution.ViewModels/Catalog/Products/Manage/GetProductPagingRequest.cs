using PShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PShopSolution.ViewModels.Catalog.Products.Manage
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string Keywork { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
