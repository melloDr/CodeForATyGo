using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CE.Application.Details;
using CE.Application.OrderS;
using CE.ViewModel.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ccElectricRent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IDetailService _dService;

        public OrderDetailController(IDetailService dService)
        {
            _dService = dService;
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetOrderDetailPaging request)
        {
            var or = await _dService.GetAllPaging(request);
            return Ok(or);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderDetailCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _dService.Create(request);

            if (!result.IsSuccessed)
            {
                return StatusCode(StatusCodes.Status403Forbidden, result);
            }
            return Ok(result);
        }

        [HttpGet("GetOrderDetailbyId/{orderId}")]
        public async Task<IActionResult> GetOrderDetailbyId(int orderId)
        {
            var categories = await _dService.GetOrderDetailbyId(orderId);
            return Ok(categories);
        }

    }
}
