using CE.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.ViewModel.System.Users
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public string RoleName { get; set; }
    }
}
