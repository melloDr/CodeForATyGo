using System;
using System.Collections.Generic;
using System.Text;

namespace CE.ViewModel.Order
{
    public class CheckOutOrderVms
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
