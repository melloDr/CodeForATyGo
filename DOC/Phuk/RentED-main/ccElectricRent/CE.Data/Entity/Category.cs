using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Entity
{
    public class Category
    {
        public int CategoryId { set; get; }
        public string CategoryName { get; set; }
        public string Thumbnail { get; set; }
        public List<Product> Products { get; set; }

    }
}
