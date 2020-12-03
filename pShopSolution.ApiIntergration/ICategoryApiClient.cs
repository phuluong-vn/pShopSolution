using PShopSolution.ViewModels.Catalog.Categories;
using PShopSolution.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pShopSolution.ApiIntergration
{
    public interface ICategoryApiClient
    {
        Task<List<CategoryVm>> GetAll(string languageId);
    }
}