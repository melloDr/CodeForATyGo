using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Entity
{
    public class CartDetail
    {
        public int CartDeltailId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int CartId { get; set; }
        public Product Product { get; set; }
        public Cart Cart { get; set; }
    }
}
