using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Entity
{
   public class AppUser : IdentityUser<string>
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Order> Orders { get; set; }
    }
}
