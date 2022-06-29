using CE.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.ViewModel.Cart
{
   public class CartViewModels
    {
        public int CartId { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public CartStatus Status { get; set; }
        public List<CartDetailViewModels> CartDetails { get; set; }
    }
}
