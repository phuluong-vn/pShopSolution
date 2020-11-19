using Microsoft.AspNetCore.Mvc;
using pShopSolution.Application.Catalog.Products;
using System.Threading.Tasks;

namespace pShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService;
        public ProductController(IPublicProductService publicProductService)
        {
            _publicProductService = publicProductService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products= await _publicProductService.GetAll();
            return Ok(products);
        }
    }
}