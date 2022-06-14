using System;
using System.Collections.Generic;

namespace BookMyShow_BE.Models
{
    public partial class Shows
    {
        public int ShowId { get; set; }
        public int Tickets { get; set; }
        public int MovieId { get; set; }
        public int TheaterId { get; set; }

        public virtual Movies Movie { get; set; } = null!;
        public virtual Theaters Theater { get; set; } = null!;
    }
}
