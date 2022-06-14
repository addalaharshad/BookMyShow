using System;
using System.Collections.Generic;

namespace BookMyShow_BE.Models
{
    public partial class BookingStatus
    {
        public int MovieId { get; set; }
        public int TheaterId { get; set; }
        public int ShowId { get; set; }
        public int UserId { get; set; }
        public int TicketsBooked { get; set; }
    }
}
