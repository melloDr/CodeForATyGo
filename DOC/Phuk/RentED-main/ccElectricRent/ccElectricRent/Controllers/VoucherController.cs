using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CE.Application.Vouchers;
using CE.ViewModel.Voucher;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ccElectricRent.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherService _voucherService;

        public VoucherController(IVoucherService voucherService)
        {
            _voucherService = voucherService;
        }

        [HttpGet("{voucherId}")]
        public async Task<IActionResult> GetByID(int voucherId)
        {
            var voucher = await _voucherService.GetByID(voucherId);
            return Ok(voucher);
        }

        [HttpGet("paging")]
        public async Task<IActionResult> GetVoucherPaging([FromQuery] GetVoucherPagingRequest request)
        {
            var voucher = await _voucherService.GetVoucherPaging(request);
            return Ok(voucher);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] VoucherCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _voucherService.Create(request);

            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("{voucherId}")]
        public async Task<IActionResult> Update(int voucherId, [FromForm] VoucherUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _voucherService.Update(voucherId, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
