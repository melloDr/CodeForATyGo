using CE.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.ViewModel.SpecificA
{
    public class GetManageSpecificPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
