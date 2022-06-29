using CE.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.ViewModel.Cart
{
    public class CartCreateRequest
    {
        public string UserId { get; set; }
        public CartStatus Status { get; set; }
    }
}
