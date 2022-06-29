using CE.ViewModel.Cart;
using CE.ViewModel.Common;
using CE.ViewModel.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CE.Application.CartS
{
    public interface ICartService
    {
       public Task<ApiResult<bool>> Create(CartCreateRequest request);

    }
}
