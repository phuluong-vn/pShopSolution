using pShopSolution.Application.Catalog.Products.Dtos;
using pShopSolution.Application.Dtos;

namespace pShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        PageViewModel<ProductViewModel> GetAllByCategoryID(int categoryId, int pageIndex, int pageSize);
    }
}