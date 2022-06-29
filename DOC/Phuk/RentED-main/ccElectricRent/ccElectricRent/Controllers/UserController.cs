using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CE.Application.System.Users;
using CE.ViewModel.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ccElectricRent.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromForm] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _userService.Authenticate(request);
            if (result.ResultObj == null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromForm] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _userService.Register(request);
            if (!result.IsSuccessed)
            {
                return StatusCode(StatusCodes.Status403Forbidden, result);
            }
            return Ok(result);
        }

        //PUT: http://localhost/api/users/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromForm] UserUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _userService.Update(id, request);
            if (!result.IsSuccessed)
            {
                return StatusCode(StatusCodes.Status403Forbidden, result);
            }
            return Ok(result);
        }


        //http://localhost/api/users/paging?pageIndex=1&pageSize=10&keyword=
        [HttpGet("paging")]
        public async Task<IActionResult> GetAllPaging([FromQuery] GetUserPagingRequest request)
        {
            var products = await _userService.GetUsersPaging(request);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var user = await _userService.GetById(id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _userService.Delete(id);
            return Ok(result);
        }

        [HttpPut("ChangePassword/{id}")]
        public async Task<IActionResult> ChangePassword(string id, [FromBody] ChangePasswordRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _userService.ChangePassword(id, request);
            if (!result.IsSuccessed)
            {
                return StatusCode(StatusCodes.Status403Forbidden, result);
            }
            return Ok(result);
        }
    }
}
