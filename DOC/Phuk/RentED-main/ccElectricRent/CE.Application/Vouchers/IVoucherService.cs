using CE.ViewModel.Common;
using CE.ViewModel.Voucher;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CE.Application.Vouchers
{
    public interface IVoucherService
    {
        Task<ApiResult<bool>> Create(VoucherCreateRequest request);
        Task<ApiResult<bool>> Update(int voucherId, VoucherUpdateRequest request);
        Task<ApiResult<PagedResult<VoucherViewModels>>> GetVoucherPaging(GetVoucherPagingRequest request);
        Task<ApiResult<VoucherViewModels>> GetByID(int voucherId);
        Task<int> Delete(int voucherId);
    }
}
