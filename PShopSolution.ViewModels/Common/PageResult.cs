using System.Collections.Generic;

namespace PShopSolution.ViewModels.Common
{
    public class PageResult<T> : PageResultBase
    {
        public List<T> Items { get; set; }
    }
}