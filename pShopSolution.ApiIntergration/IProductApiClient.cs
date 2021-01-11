using pShopSolution.Application.Catalog.Products;
using PShopSolution.ViewModels.Catalog.Products;
using PShopSolution.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pShopSolution.ApiIntergration
{
    public interface IProductApiClient
    {
        Task<PageResult<ProductVm>> GetProductPagings(GetManageProductPagingRequest request);

        Task<bool> CreateProduct(ProductCreateRequest request);

        Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);

        Task<ProductVm> GetById(int productId, string languageId);

        Task<List<ProductVm>> GetFeatureProducts(string languageId, int take);

        Task<List<ProductVm>> GetLatestProducts(string languageId, int take);
    }
}