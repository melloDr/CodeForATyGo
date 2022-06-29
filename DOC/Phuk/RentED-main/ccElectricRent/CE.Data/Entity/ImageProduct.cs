using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Entity
{
    public class ImageProduct
    {
        public int ImageId { get; set; }
        public string Url { get; set; }
        public int PrlItemId { get; set; }
        public ProductItem ProductItem { get; set; }
    }
}
