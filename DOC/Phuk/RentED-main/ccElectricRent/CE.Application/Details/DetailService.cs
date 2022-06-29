using CE.Data.EF;
using CE.Data.Entity;
using CE.ViewModel.Common;
using CE.ViewModel.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Application.Details
{
    public class DetailService : IDetailService
    {
        private readonly CeDbContext _context;
        public DetailService(CeDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> Create(OrderDetailCreateRequest request)
        {
            Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
            if (errors.Count() > 0)
            {
                return new ApiErrorResult<bool>(errors);
            }
            var oDe = new OrderDetail()
            {
                ProductId = request.ProductId,
                OrderId = request.OrderId,
                Quantity = request.Quantity,
                RentDate = request.RentDate,
                ReturnDate = request.ReturnDate
            };
            _context.OrderDetails.Add(oDe);

            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Create OrderDetial failed");
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<PagedResult<OrderDetailViewModels>>> GetAllPaging(GetOrderDetailPaging request)
        {
            var query = from od in _context.OrderDetails
                        join p in _context.Products on od.ProductId equals p.ProductId
                        join o in _context.Orders on od.OrderId equals o.OrderId
                        select new { p, od,o };
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize).Select(x => new OrderDetailViewModels()
                {
                    OrderDetailId = x.od.OrderDetailId,
                    OrderId = x.od.OrderId,
                    Quantity = x.od.Quantity,
                    RentDate =x.od.RentDate,
                    ReturnDate = x.od.ReturnDate,
                    ProductId = x.p.ProductId
                }).ToListAsync();
            var pagedResult = new PagedResult<OrderDetailViewModels>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };

            return new ApiSuccessResult<PagedResult<OrderDetailViewModels>>(pagedResult);
        }

        public async Task<ApiResult<List<OrderDetailViewModels>>> GetOrderDetailbyId(int orderId)
        {
            var query = from od in _context.OrderDetails
                        join o in _context.Orders on od.OrderId equals o.OrderId
                        select new { o, od };
            var data = await query.Where(x => x.od.OrderId.Equals(orderId))
               .Select(x => new OrderDetailViewModels()
               {
                   OrderDetailId = x.od.OrderDetailId,
                   Quantity = x.od.Quantity,
                   RentDate = x.od.RentDate,
                   ReturnDate = x.od.ReturnDate,
                   ProductId = x.od.ProductId,
                   OrderId = x.od.OrderId
               }).ToListAsync();

            return new ApiSuccessResult<List<OrderDetailViewModels>>(data);
        }
    }
}
