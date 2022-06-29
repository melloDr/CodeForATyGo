using CE.Data.EF;
using CE.Data.Entity;
using CE.Data.Enum;
using CE.ViewModel.Common;
using CE.ViewModel.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Application.OrderS
{
    public class OrderService : IOrderService
    {
        private readonly CeDbContext _context;
        public OrderService(CeDbContext context)
        {
            _context = context;
        }

        
        public async Task<ApiResult<bool>> Create(OrderCreateRequest request)
        {
            Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
            if (errors.Count() > 0)
            {
                return new ApiErrorResult<bool>(errors);
            }
            var ord = new Order()
            {
                UserId = request.UserId,
                VoucherId = request.VoucherId,
                TotalPrice = request.TotalPrice,
                CreateDate = request.CreateDate,
                Status = request.Status
            };
            _context.Orders.Add(ord);

            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Create Order failed");
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<PagedResult<OrderViewModels>>> GetAllPaging(GetManageOrderPagingRequest1 request)
        {
            var query = from o in _context.Orders
                        join u in _context.AppUsers on o.UserId equals u.Id                     
                        select new { u, o };
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize).Select(x => new OrderViewModels()
                {
                    OrderId = x.o.OrderId,
                    UserId = x.u.Id,
                    Address= x.u.Address,
                    FullName= x.u.FullName,
                    PhoneNumber= x.u.PhoneNumber,
                    VoucherId = x.o.VoucherId,
                    TotalPrice = x.o.TotalPrice,
                    CreateDate = x.o.CreateDate,
                    Status = x.o.Status
                }).ToListAsync();
            var pagedResult = new PagedResult<OrderViewModels>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };

            return new ApiSuccessResult<PagedResult<OrderViewModels>>(pagedResult);
        }


        public async Task<ApiResult<bool>> UpdateStatus(int orderId, UpdateOrderStatus request)
        {
            Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
            var o = await _context.Orders.FindAsync(orderId);
            if (o == null) return new ApiErrorResult<bool>("Order does not exist");
            if (errors.Count() > 0)
            {
                return new ApiErrorResult<bool>(errors);
            }
            o.Status = request.Status;
            _context.Orders.Update(o);
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Update OrderStatus failed");
            }
            return new ApiSuccessResult<bool>();
        }
    }
}

