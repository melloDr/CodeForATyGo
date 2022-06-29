using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CE.Application.ProductA;
using CE.ViewModel.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ccElectricRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IProductService _productService;

        public CategoriesController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCate([FromBody] CategoriesCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _productService.CreateCate(request);

            if (!result.IsSuccessed)
            {
                return StatusCode(StatusCodes.Status403Forbidden, result);
            }
            return Ok(result);
        }
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllCatePaging([FromQuery] GetManageCatePagingRequest1 request)
        {
            var products = await _productService.GetAllCatePaging(request);
            return Ok(products);
        }
    }
}
