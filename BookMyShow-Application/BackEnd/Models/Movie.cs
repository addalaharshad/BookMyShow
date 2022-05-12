using System;
using System.Collections.Generic;

namespace BookMyShow_BE.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Language { get; set; } = null!;
    }
}
