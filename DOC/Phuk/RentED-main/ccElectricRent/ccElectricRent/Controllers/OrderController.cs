using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CE.Application.OrderS;
using CE.ViewModel.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ccElectricRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _ordService;

        public OrderController(IOrderService ordService)
        {
            _ordService = ordService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _ordService.Create(request);

            if (!result.IsSuccessed)
            {
                return StatusCode(StatusCodes.Status403Forbidden, result);
            }
            return Ok(result);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetManageOrderPagingRequest1 request)
        {
            var or = await _ordService.GetAllPaging(request);
            return Ok(or);
        }

        [HttpPut("changeStatus/{orderId}")]
        public async Task<IActionResult> UpdateStatus(int orderId, [FromBody] UpdateOrderStatus request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _ordService.UpdateStatus(orderId, request);

            if (!result.IsSuccessed)
            {
                return StatusCode(StatusCodes.Status403Forbidden, result);
            }
            return Ok(result);
        }
    }
}