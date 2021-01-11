using PShopSolution.ViewModels.Utilities.Slides;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pShopSolution.ApiIntergration
{
    public interface ISlideApiClient
    {
        Task<List<SlideVm>> GetAll();
    }
}