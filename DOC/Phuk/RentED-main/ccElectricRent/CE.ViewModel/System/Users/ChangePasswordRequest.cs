using System;
using System.Collections.Generic;
using System.Text;

namespace CE.ViewModel.System.Users
{
    public class ChangePasswordRequest
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
