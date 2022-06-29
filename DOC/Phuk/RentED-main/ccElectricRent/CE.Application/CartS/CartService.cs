using CE.Application.Ultilities;
using CE.Data.EF;
using CE.Data.Entity;
using CE.ViewModel.Cart;
using CE.ViewModel.Common;
using CE.ViewModel.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Application.CartS
{
    public class CartService : ICartService
    {
        private readonly CeDbContext _context;
        public CartService(CeDbContext context)
        {
            _context = context;
        }

      

        public async Task<ApiResult<bool>> Create(CartCreateRequest request)
        {
            Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
            if (errors.Count() > 0)
            {
                return new ApiErrorResult<bool>(errors);
            }
            var cart = new Cart()
            {
                UserId = request.UserId,
                Status = request.Status
            };
            _context.Carts.Add(cart);

            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Create Cart failed");
            }
            return new ApiSuccessResult<bool>();
        }

       
    }
}
