using System;
using System.Collections.Generic;

namespace BookMyShow_BE.Models
{
    public partial class Theaters
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Location { get; set; }
    }
}
