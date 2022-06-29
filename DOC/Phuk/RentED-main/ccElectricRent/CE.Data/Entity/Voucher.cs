using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Entity
{
    public class Voucher
    {
        public int? VoucherId { set; get; }
        public string VoucherName { set; get; }
        public float SaleOff { set; get; }
        public DateTime StartDate { set; get; }
        public DateTime FinishDate { set; get; }  
        public List<Order> Orders { get; set; }

    }
}
