using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Entity
{
    public class OrderDetail
    {
        public int OrderDetailId { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public DateTime RentDate { set; get; }
        public DateTime ReturnDate { set; get; }
        public int OrderId { set; get; }
        public Product Product { set; get; }
        public Order Order { set; get; }


    }
}
