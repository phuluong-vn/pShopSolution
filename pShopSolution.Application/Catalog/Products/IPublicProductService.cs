using PShopSolution.ViewModels.Catalog.Products;
using PShopSolution.ViewModels.Catalog.Products.Public;
using PShopSolution.ViewModels.Common;
using System.Threading.Tasks;

namespace pShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PageResult<ProductViewModel>> GetAllByCategoryID(GetProductPagingRequest request);
    }
}