using PShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PShopSolution.ViewModels.Catalog.Products
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
        public string Keywork { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
