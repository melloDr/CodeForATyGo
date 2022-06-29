using CE.ViewModel.Cart;
using CE.ViewModel.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.ViewModel.Products
{
    public class ProductVms
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? CatagoryId { set; get; }
        public string CatagoryName { set; get; }
        public List<CartDetailViewModels> CartDetails { get; set; }
        public List<OrderDetailViewModels> OrderDetails { get; set; }

        //public List<ProductItemViewModels> ProductItems { get; set; }
        //public List<SpecificViewModels> Specifics { get; set; }
    }
}
