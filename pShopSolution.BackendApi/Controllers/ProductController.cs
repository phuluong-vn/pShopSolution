using Microsoft.AspNetCore.Mvc;
using pShopSolution.Application.Catalog.Products;
using PShopSolution.ViewModels.Catalog.Products;
using System.Threading.Tasks;

namespace pShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService;
        private readonly IManageProductService _manageProductService;

        public ProductController(IPublicProductService publicProductService, IManageProductService manageProductService)
        {
            _publicProductService = publicProductService;
            _manageProductService = manageProductService;
        }

        //https:localhost:port/product
        [HttpGet("{languageId}")]
        public async Task<IActionResult> GetAll(string languageId)
        {
            var products = await _publicProductService.GetAll(languageId);
            return Ok(products);
        }
        //https:localhost:port/product/1
        [HttpGet("{id}/{languageId}")]
        public async Task<IActionResult> GetProductById(int id, string languageId)
        {
            var product = await _manageProductService.GetById(id, languageId);
            if (product == null)
                return BadRequest("Cannot find product");
            return Ok(product);
        }
        [HttpGet("public-paging/{languageId}")]
        public async Task<IActionResult> GetAllByCategoryId([FromQuery] GetPublicProductPagingRequest request)
        {
            var products = await _publicProductService.GetAllByCategoryID(request);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            var productId = await _manageProductService.Create(request);
            if (productId == 0)
                return BadRequest();
            var product = await _manageProductService.GetById(productId, request.LanguageId);
            return Created(nameof(GetProductById), product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            var productId = await _manageProductService.Update(request);
            if (productId == 0)
                return BadRequest();
            return Ok();
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _manageProductService.Delete(id);
            if (result == 0)
                return BadRequest();
            return Ok();
        }
        [HttpPut("price/{id}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int id, decimal newPrice)
        {
            var result = await _manageProductService.UpdatePrice(id,newPrice);
            if (result) 
                return Ok();
            return BadRequest();
        }

    }
}