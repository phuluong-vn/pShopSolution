using pShopSolution.Application.Catalog.Products.Dtos;
using pShopSolution.Application.Catalog.Products.Dtos.Manage;
using pShopSolution.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pShopSolution.Application.Catalog.Products
{
    public interface IManageProductService //định nghĩa các phương thức
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int ProductId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task<int> UpdateStock(int productid, int addedQuantity);

        Task<int> AddViewCount(int productId);

        Task<List<ProductViewModel>> GetAll();

        Task<PageResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);
    }
}