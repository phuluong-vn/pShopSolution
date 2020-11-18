using pShopSolution.Application.Catalog.Products.Dtos;
using pShopSolution.Application.Catalog.Products.Dtos.Public;
using pShopSolution.Application.Dtos;
using System.Threading.Tasks;

namespace pShopSolution.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PageResult<ProductViewModel>> GetAllByCategoryID(GetProductPagingRequest request);
    }
}