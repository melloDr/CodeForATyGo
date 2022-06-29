using CE.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CE.Data.Entity
{
    public class Product
    {
        public int ProductId { set; get; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public double Price { set; get; }
        public string ThumbNail { get; set; }
        public ProductStatus Status { get; set; }
        public List<ProductItem> ProductItems { get; set; }
        public List<CartDetail> CartDetails { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Specific> Specifics { get; set; }
        public Category Category { get; set; }
    }
}