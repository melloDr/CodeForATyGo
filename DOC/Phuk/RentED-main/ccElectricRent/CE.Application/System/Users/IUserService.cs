using CE.ViewModel.Common;
using CE.ViewModel.System.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CE.Application.System.Users
{
  public interface IUserService
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);

        Task<ApiResult<string>> Register(RegisterRequest request);

        Task<ApiResult<bool>> Update(string id, UserUpdateRequest request);

        Task<ApiResult<PagedResult<UserViewModels>>> GetUsersPaging(GetUserPagingRequest request);

        Task<ApiResult<UserViewModels>> GetById(string id);

        Task<ApiResult<bool>> Delete(string id);
        Task<ApiResult<bool>> ChangePassword(string id, ChangePasswordRequest request);
    }
}
