using CE.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Entity
{
   public class Order
    {
        public int OrderId { set; get; }
        public double TotalPrice { get; set; }
        public DateTime CreateDate { set; get; }
        public string UserId { set; get; }
        public int? VoucherId { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public Voucher Voucher { get; set; }
        public AppUser AppUser { get; set; }


    }
}
