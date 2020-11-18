using pShopSolution.Application.Catalog.Products.Dtos;
using pShopSolution.Application.Catalog.Products.Dtos.Public;
using pShopSolution.Application.Dtos;

namespace pShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        PageResult<ProductViewModel> GetAllByCategoryID(GetProductPagingRequest request);
    }
}