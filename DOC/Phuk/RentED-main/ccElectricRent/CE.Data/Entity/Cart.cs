using CE.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Entity
{
    public class Cart
    {
        public int CartId { set; get; }
        public string UserId { set; get; }
        public CartStatus Status { get; set; }
        public List<CartDetail> CartDetails { get; set; }
        public AppUser AppUser { get; set; }
    }
}
