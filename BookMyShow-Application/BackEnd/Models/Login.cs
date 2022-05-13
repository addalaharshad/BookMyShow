using System;
using System.Collections.Generic;

namespace BookMyShow_BE.Models
{
    public partial class Login
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
