using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Entity
{
    public class Specific
    {
        public int SpecId { get; set; }
        public int ProductId { get; set; }
        public string ProductKey { get; set; }
        public string Value { get; set; }
        public Product Product { get; set; }
    }
}
