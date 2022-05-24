using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BookMyShow_BE.Models
{
    public partial class Login : IdentityUser
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
