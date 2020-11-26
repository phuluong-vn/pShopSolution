using Microsoft.AspNetCore.Mvc;
using PShopSolution.ViewModels.Common;
using System.Threading.Tasks;

namespace pShopSolution.AdminApp.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PageResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}