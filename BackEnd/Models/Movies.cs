using System;
using System.Collections.Generic;

namespace BookMyShow_BE.Models
{
    public partial class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Language { get; set; } = null!;
        public DateTime? RealesedOn { get; set; }
        public string? MoviePath { get; set; }
    }
}
