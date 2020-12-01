using Microsoft.AspNetCore.Http;
using PShopSolution.ViewModels.Catalog.ProductImages;
using PShopSolution.ViewModels.Catalog.Products;
using PShopSolution.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pShopSolution.Application.Catalog.Products
{
    public interface IProductService //định nghĩa các phương thức
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int ProductId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task<bool> UpdateStock(int productid, int addedQuantity);

        Task<int> AddViewCount(int productId);

        Task<PageResult<ProductVm>> GetAllPaging(GetManageProductPagingRequest request);

        Task<ProductVm> GetById(int productId, string languageId);

        Task<int> AddImage(int productId, ProductImageCreateRequest request);

        Task<int> RemoveImage(int imageId);

        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);

        Task<List<ProductImageViewModel>> GetListImages(int productId);

        Task<ProductImageViewModel> GetProductImageById(int imageId);

        Task<PageResult<ProductVm>> GetAllByCategoryID(string languageId, GetPublicProductPagingRequest request);
    }
}