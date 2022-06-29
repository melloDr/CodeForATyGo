using CE.Application.Ultilities;
using CE.Data.EF;
using CE.Data.Entity;
using CE.ViewModel.Common;
using CE.ViewModel.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PasswordGenerator;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CE.Application.System.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly CeDbContext _context;
        private readonly IConfiguration _config;

        public UserService(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppRole> roleManager,
            CeDbContext context,
            IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
            _context = context;
        }

        public async Task<ApiResult<string>> Authenticate(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
                return new ApiErrorResult<string>("This account does not exist");

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return new ApiErrorResult<string>("Password is not correct");
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName, user.FullName),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Role, string.Join(";",roles))
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new ApiSuccessResult<string>(           
                new JwtSecurityTokenHandler().WriteToken(token)           
            );
        }

        public async Task<ApiResult<bool>> ChangePassword(string id, ChangePasswordRequest request)
        {
            Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("This account does not exist");
            }
            var result1 = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, request.CurrentPassword);
            if (result1 != PasswordVerificationResult.Success)
            {
                UltilitiesService.AddOrUpdateError(errors, "CurrentPassword", "Your current password is not correct");
            }
            if (errors.Count > 0)
            {
                return new ApiErrorResult<bool>(errors);
            }

            string errorMessage = null;

            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            foreach (var error in result.Errors)
            {
                errorMessage += error.Description + Environment.NewLine;
            }
            return new ApiErrorResult<bool>("Change password failed" + errorMessage);
        }

        public async Task<ApiResult<bool>> Delete(string id)
        {

            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("User does not exist");
            }
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            return new ApiErrorResult<bool>("Delete user failed");
        }


        public async Task<ApiResult<UserViewModels>> GetById(string id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<UserViewModels>("User not existed");
            }
            var roles = await _userManager.GetRolesAsync(user);
            string currentRole = null;
            if (roles.Count > 0)
            {
                currentRole = roles[0];
            }
            var userVm = new UserViewModels()
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                FullName = user.FullName,
                Address= user.Address,
                Id = user.Id,
                UserName = user.UserName,
                RoleName = currentRole
            };
            return new ApiSuccessResult<UserViewModels>(userVm);
        }

        public async Task<ApiResult<PagedResult<UserViewModels>>> GetUsersPaging(GetUserPagingRequest request)
        {
            var query = from u in _userManager.Users
                        join ur in _context.UserRoles on u.Id equals ur.UserId
                        join r in _context.Roles on ur.RoleId equals r.Id
                        select new { u, r, ur };
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => (x.u.UserName.Contains(request.Keyword) || x.u.FullName.Contains(request.Keyword) || x.u.PhoneNumber.Contains(request.Keyword)
                || x.u.Email.Contains(request.Keyword)) && x.r.Name == request.RoleName);
            }
            else
            {
                query = query.Where(x => x.r.Name == request.RoleName);
            }
            //3.Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new UserViewModels()
                {
                    Email = x.u.Email,
                    PhoneNumber = x.u.PhoneNumber,
                    FullName = x.u.FullName,
                    Id = x.u.Id,
                    UserName = x.u.UserName,
                    Address = x.u.Address,
                    RoleName = x.r.Name
                }).ToListAsync();
           
            //4.Select and projection
            var pagedResult = new PagedResult<UserViewModels>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return new ApiSuccessResult<PagedResult<UserViewModels>>(pagedResult);
        }

        public async Task<ApiResult<string>> Register(RegisterRequest request)
        {
            Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user != null)
            {
                UltilitiesService.AddOrUpdateError(errors, "UserName", "This username alreadys exists");
                //return new ApiErrorResult<string>("Username: This username already exists");
            }
            if (await _userManager.FindByEmailAsync(request.Email) != null)
            {
                UltilitiesService.AddOrUpdateError(errors, "Email", "This email already exists");
                //return new ApiErrorResult<string>("Email: This email already exists");
            }
            if (errors.Count > 0)
            {
                return new ApiErrorResult<string>(errors);
            }
            user = new AppUser()
            {
                FullName = request.FullName,
                Address = request.Address,
                Email = request.Email,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
            };
            var pwd = new Password().IncludeLowercase().IncludeUppercase().IncludeNumeric().LengthRequired(8);
            var presult = pwd.Next();
            string password = "Abcd1234$";

            string errorMessage = null;
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                if (await _userManager.IsInRoleAsync(user, request.RoleName) == false)
                {
                    var addtoroleResult = await _userManager.AddToRoleAsync(user, request.RoleName);
                    if (!addtoroleResult.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            errorMessage += error.Description + Environment.NewLine;
                        }
                        return new ApiErrorResult<string>("Register failed: " + errorMessage);
                    }
                }
                user = await _userManager.FindByNameAsync(request.UserName);
                string empID = user.Id;
                return new ApiSuccessResult<string>(empID);
            }

            foreach (var error in result.Errors)
            {
                errorMessage += error.Description + Environment.NewLine;
            }
            return new ApiErrorResult<string>("Register failed: " + errorMessage);
        }

        public async Task<ApiResult<bool>> Update(string id, UserUpdateRequest request)
        {
            Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

            if (await _userManager.Users.AnyAsync(x => x.Email.Equals(request.Email) && x.Id != id))
            {
                UltilitiesService.AddOrUpdateError(errors, "Email", "Email already exists");
            }
            if (errors.Count > 0)
            {
                return new ApiErrorResult<bool>(errors);
            }
            var user = await _userManager.FindByIdAsync(id.ToString());
            user.Address = request.Address;
            user.Email = request.Email;
            user.FullName = request.FullName;
            user.PhoneNumber = request.PhoneNumber;
            var result = await _userManager.UpdateAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            string errorMessage = null;
            if (await _userManager.IsInRoleAsync(user, request.RoleName) == false)
            {
                foreach (string rolename in roles)
                {
                    if (await _userManager.IsInRoleAsync(user, rolename) == true)
                    {
                        var removefromroleResult = await _userManager.RemoveFromRoleAsync(user, rolename);
                        if (!removefromroleResult.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                errorMessage += error.Description + Environment.NewLine;
                            }
                            return new ApiErrorResult<bool>("Update user failed: " + errorMessage);
                        }
                    }
                }
                var addtoroleResult = await _userManager.AddToRoleAsync(user, request.RoleName);
                if (!addtoroleResult.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        errorMessage += error.Description + Environment.NewLine;
                    }
                    return new ApiErrorResult<bool>("Update user failed: " + errorMessage);
                }
            }
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            foreach (var error in result.Errors)
            {
                errorMessage += error.Description + Environment.NewLine;
            }
            return new ApiErrorResult<bool>("Update user failed: " + errorMessage);
        }
    }
}
