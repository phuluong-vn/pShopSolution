using PShopSolution.ViewModels.Catalog.Products;
using PShopSolution.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PageResult<ProductViewModel>> GetAllByCategoryID(GetPublicProductPagingRequest request);
        Task<List<ProductViewModel>> GetAll(string languageId);
    }
}