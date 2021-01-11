using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pShopSolution.Application.Catalog.Products;
using PShopSolution.ViewModels.Catalog.ProductImages;
using PShopSolution.ViewModels.Catalog.Products;
using System.Threading.Tasks;

namespace pShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //https:localhost:port/product/1
        [HttpGet("{productId}/{languageId}")]
        [Authorize]
        public async Task<IActionResult> GetProductById(int productId, string languageId)
        {
            var product = await _productService.GetById(productId, languageId);
            if (product == null)
                return BadRequest("Cannot find product");
            return Ok(product);
        }

        //[HttpGet("{languageId}")]
        //public async Task<IActionResult> GetAllByCategoryId(string languageId, [FromQuery] GetPublicProductPagingRequest request)
        //{
        //    var products = await _productService.GetAllByCategoryID(languageId, request);
        //    return Ok(products);
        //}

        [HttpGet("{paging}")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageProductPagingRequest request)
        {
            var products = await _productService.GetAllPaging(request);
            return Ok(products);
        }

        [HttpGet("feature/{languageId}/{take}")]
        public async Task<IActionResult> GetFeatureProducts(string languageId, int take)
        {
            var products = await _productService.GetFeatureProducts(languageId, take);
            return Ok(products);
        }

        [HttpGet("latest/{languageId}/{take}")]
        public async Task<IActionResult> GetLatestProducts(string languageId, int take)
        {
            var products = await _productService.GetLatestProducts(languageId, take);
            return Ok(products);
        }

        [HttpPost]
        [Consumes("multipart/Form-data")]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _productService.Create(request);
            if (productId == 0)
                return BadRequest();
            var product = await _productService.GetById(productId, request.LanguageId);
            return Created(nameof(GetProductById), product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _productService.Update(request);
            if (productId == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("productId")]
        public async Task<IActionResult> Delete(int productId)
        {
            var result = await _productService.Delete(productId);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPatch("{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice)
        {
            var result = await _productService.UpdatePrice(productId, newPrice);
            if (result)
                return Ok();
            return BadRequest();
        }

        //Images
        [HttpPost("{productId}/images")]
        public async Task<IActionResult> CreateImage(int productId, [FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productImageId = await _productService.AddImage(productId, request);
            if (productId == 0)
                return BadRequest();
            var product = await _productService.GetProductImageById(productImageId);
            return CreatedAtAction(nameof(GetProductById), new { id = productId }, product);
        }

        [HttpPut("{productId}/images/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var image = await _productService.GetProductImageById(imageId);
            if (image == null)
                return BadRequest();
            var result = await _productService.UpdateImage(imageId, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPost("{productId}/images/{imageId}")]
        public async Task<IActionResult> GetImageById(int imageId)
        {
            var image = await _productService.GetProductImageById(imageId);
            if (image == null)
                return BadRequest();
            return Ok(image);
        }

        [HttpDelete("{productId}/images/{imageId}")]
        public async Task<IActionResult> DeleteImage(int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var image = await _productService.GetProductImageById(imageId);
            if (image == null)
                return BadRequest();
            var result = await _productService.RemoveImage(imageId);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPut("{productId}/categories")]
        public async Task<IActionResult> CategoryAssign(int productId, [FromBody] CategoryAssignRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _productService.CategoryAssign(productId, request);
            if (!result.IsSuccessed)
                return BadRequest(result);
            return Ok(result);
        }
    }
}