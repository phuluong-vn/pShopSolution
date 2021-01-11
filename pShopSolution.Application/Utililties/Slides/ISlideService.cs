using PShopSolution.ViewModels.Utilities.Slides;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pShopSolution.Application.Utililties.Slides
{
    public interface ISlideService
    {
        Task<List<SlideVm>> GetAll();
    }
}