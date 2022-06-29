using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CE.Application.CartS;
using CE.ViewModel.Cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ccElectricRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CartCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _cartService.Create(request);

            if (!result.IsSuccessed)
            {
                return StatusCode(StatusCodes.Status403Forbidden, result);
            }
            return Ok(result);
        }
    }
}
