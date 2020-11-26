using System;
using System.Collections.Generic;
using System.Text;

namespace PShopSolution.ViewModels.Common
{
    public class PageResultBase
    {
        public int PageIndex { get; set; }
        public int PageSise { get; set; }
        public int TotalRecord { get; set; }

        public int PageCount
        {
            get
            {
                var pageCount = (double)TotalRecord / PageSise;
                return (int)Math.Ceiling(pageCount);
            }
        }
    }
}