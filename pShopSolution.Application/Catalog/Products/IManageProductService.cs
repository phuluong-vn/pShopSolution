using pShopSolution.Application.Catalog.Products.Dtos;
using pShopSolution.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pShopSolution.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int ProductId);

        Task<List<ProductViewModel>> GetAll();

        Task<PageViewModel<ProductViewModel>> GetAllPaging(string keyword, int pageIndex, int pageSize);
    }
}