using CE.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.ViewModel.Order
{
    public class OrderCreateRequest
    {
        public string UserId { get; set; }
        public int VoucherId { get; set; }
        public double TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
