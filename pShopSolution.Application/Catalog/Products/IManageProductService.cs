using Microsoft.AspNetCore.Http;
using PShopSolution.ViewModels.Catalog.Products;
using PShopSolution.ViewModels.Common;
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

        Task<bool> UpdateStock(int productid, int addedQuantity);

        Task<int> AddViewCount(int productId);

        Task<PageResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        Task<int> AddImages(int productId, List<IFormFile> files);

        Task<int> RemoveImages(int imageId);

        Task<int> UpdateImages(int imageId, string caption, bool isDefault);

        Task<List<ProductImageViewModel>> GetListImage(int productId);

        Task<ProductViewModel> GetById(int productId, string languageId);
    }
}