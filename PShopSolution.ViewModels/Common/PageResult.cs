using System.Collections.Generic;

namespace PShopSolution.ViewModels.Common
{
    public class PageResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalRecord { get; set; }
    }
}