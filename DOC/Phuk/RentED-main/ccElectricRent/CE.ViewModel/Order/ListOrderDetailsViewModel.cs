using CE.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.ViewModel.Order
{
    public class ListOrderDetailsViewModel
    {
        public bool IsCreateNew { get; set; }
        public PagedResult<OrderDetailViewModels> Data { get; set; }
    }
}
