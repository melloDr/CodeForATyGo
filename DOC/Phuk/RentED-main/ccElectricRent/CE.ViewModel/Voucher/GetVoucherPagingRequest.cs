using CE.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.ViewModel.Voucher
{
    public class GetVoucherPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
    }
}
