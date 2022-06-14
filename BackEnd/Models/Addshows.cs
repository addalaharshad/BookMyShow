using System;
using System.Collections.Generic;

namespace BookMyShow_BE.Models
{
    public partial class Addshows
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int TheaterId { get; set; }
        public int ShowId { get; set; }
    }
}
