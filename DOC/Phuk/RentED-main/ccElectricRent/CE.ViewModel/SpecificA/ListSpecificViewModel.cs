using CE.ViewModel.Common;
using CE.ViewModel.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.ViewModel.SpecificA
{
    public class ListSpecificViewModel
    {
        public bool IsCreateNew { get; set; }
        public PagedResult<SpecificViewModels> Data { get; set; }
    }
}
