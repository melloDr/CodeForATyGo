using System;
using System.Collections.Generic;
using System.Text;

namespace CE.ViewModel.Products
{
    public class ProductCreateRequest
    {
        public string ProductName { set; get; }
        public int CatagoryId { set; get; }
        public int Quantity { set; get; }
        public string Description { set; get; }
        public double Price { set; get; }
        public string ThumbNail { get; set; }
    }
}
