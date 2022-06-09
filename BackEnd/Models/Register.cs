using System;
using System.Collections.Generic;

namespace BookMyShow_BE.Models
{
    public partial class Register
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Password { get; set; }
        public string? Mobile { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
