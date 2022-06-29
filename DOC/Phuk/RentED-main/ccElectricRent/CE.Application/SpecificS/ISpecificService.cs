using CE.ViewModel.Common;
using CE.ViewModel.SpecificA;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CE.Application.SpecificS
{
  public interface ISpecificService
    {
        Task<ApiResult<int>> Create(int productId, SpecificCreateRequest request);

        Task<ApiResult<bool>> Update(int specId, SpecificUpdateRequest request);
        Task<ApiResult<bool>> Delete(int specId);
        Task<ApiResult<SpecificViewModels>> GetByID(int specId);
        Task<ApiResult<PagedResult<SpecificViewModels>>> GetAllPaging(GetManageSpecificPagingRequest request);
        Task<ApiResult<ListSpecificViewModel>> GetSpecificByProductId(int productId, GetManageSpecificPagingRequest request);
    }
}
