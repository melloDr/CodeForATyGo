using System;
using System.Collections.Generic;
using System.Text;

namespace CE.ViewModel.Common
{
    public class ApiResult<T>
    {
        public bool IsSuccessed { get; set; }

        public string Message { get; set; }

        public Dictionary<string, List<string>> Errors { get; set; }

        public T ResultObj { get; set; }
    }
}