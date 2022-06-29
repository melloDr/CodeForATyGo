using CE.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Entity
{
  public class ProductItem
    {
        public int PrlItemId { get; set; }
        public int ProductId { get; set; }
        public  ProductItemStatus Status { get; set; }
        public List<ImageProduct> ImageProducts { get; set; }
        public Product Product { get; set; }

    }
}
