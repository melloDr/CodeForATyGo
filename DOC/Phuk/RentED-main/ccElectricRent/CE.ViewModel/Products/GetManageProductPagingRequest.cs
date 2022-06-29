using CE.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.ViewModel.Products
{
   public class GetManageProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
