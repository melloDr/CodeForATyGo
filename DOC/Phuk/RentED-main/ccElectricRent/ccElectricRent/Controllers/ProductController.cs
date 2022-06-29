using CE.Application.ProductA;
using CE.ViewModel.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ccElectricRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _productService.Create(request);

            if (!result.IsSuccessed)
            {
                return StatusCode(StatusCodes.Status403Forbidden, result);
            }
            return Ok(result);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetByID(int productId)
        {
            var p = await _productService.GetByID(productId);
            return Ok(p);
        }


        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageProductPagingRequest request)
        {
            var products = await _productService.GetAllPaging(request);
            return Ok(products);
        }


        [HttpPut("{productId}")]
        public async Task<IActionResult> Update(int productId, [FromBody] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _productService.Update(productId, request);

            if (!result.IsSuccessed)
            {
                return StatusCode(StatusCodes.Status403Forbidden, result);
            }
            return Ok(result);
        }

        [HttpGet("GetProductByCategoryId/{categoryId}")]
        public async Task<IActionResult> GetProductByCategoryId(int categoryId)
        {
            var categories = await _productService.GetProductByCategoryId(categoryId);
            return Ok(categories);
        }


        [HttpPut("changeStatus/{productId}")]
        public async Task<IActionResult> ChangeStatus(int productId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _productService.ChangeStatus(productId);
            if (!result.IsSuccessed)
            {
                return StatusCode(StatusCodes.Status400BadRequest, result);
            }
            return Ok(result);
        }

       
    }
}
