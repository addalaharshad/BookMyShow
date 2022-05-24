using System;
using System.Collections.Generic;

namespace BookMyShow_BE.Models
{
    public partial class Show
    {
        public int ShowId { get; set; }
        public int Tickets { get; set; }
        public int MovieId { get; set; }
        public int TheaterId { get; set; }

        public virtual Movie Movie { get; set; } = null!;
        public virtual Theater Theater { get; set; } = null!;
    }
}
