using System;
using System.Collections.Generic;
using System.Text;

namespace CE.ViewModel.System.Users
{
    public class UserUpdateRequest
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string RoleName { get; set; }
    }
}
