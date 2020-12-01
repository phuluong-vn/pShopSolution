using PShopSolution.ViewModels.Catalog.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pShopSolution.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryVm>> GetAll(string languageId);
    }
}