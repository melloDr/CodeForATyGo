using CE.ViewModel.Common;
using CE.ViewModel.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CE.Application.Details
{
    public interface IDetailService
    {
        public Task<ApiResult<bool>> Create(OrderDetailCreateRequest request);
        public Task<ApiResult<PagedResult<OrderDetailViewModels>>> GetAllPaging(GetOrderDetailPaging request);
        public Task<ApiResult<List<OrderDetailViewModels>>> GetOrderDetailbyId(int orderId);
    }
}
