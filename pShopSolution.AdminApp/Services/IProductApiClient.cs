using pShopSolution.Application.Catalog.Products;
using PShopSolution.ViewModels.Catalog.Products;
using PShopSolution.ViewModels.Common;
using System.Threading.Tasks;

namespace pShopSolution.AdminApp.Services
{
    public interface IProductApiClient
    {
        Task<PageResult<ProductVm>> GetProductPagings(GetManageProductPagingRequest request);

        Task<bool> CreateProduct(ProductCreateRequest request);
    }
}