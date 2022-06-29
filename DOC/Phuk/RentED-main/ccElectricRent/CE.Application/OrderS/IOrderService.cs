using CE.ViewModel.Common;
using CE.ViewModel.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CE.Application.OrderS
{
    public interface IOrderService
    {
        public Task<ApiResult<bool>> Create(OrderCreateRequest request);
        public Task<ApiResult<PagedResult<OrderViewModels>>> GetAllPaging(GetManageOrderPagingRequest1 request);
        public Task<ApiResult<bool>> UpdateStatus(int orderId, UpdateOrderStatus request);
    }
}
