using System;
using System.Collections.Generic;

namespace CAS_MVC_4.Models
{
    public partial class AdminLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public System.DateTime UpdatedOn { get; set; }
    }
}
