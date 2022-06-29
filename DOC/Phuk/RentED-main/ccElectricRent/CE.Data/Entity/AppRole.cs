using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Entity
{
   public class AppRole : IdentityRole<string>
    {
        public string Description { get; set; }
    }
}
