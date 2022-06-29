using System;
using System.Collections.Generic;
using System.Text;

namespace CE.ViewModel.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> Items { get; set; }
    }
}