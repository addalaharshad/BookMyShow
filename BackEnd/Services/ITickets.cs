

using BookMyShow_BE.Data_Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow_BE.Services
{
    public interface ITickets
    {
        public IEnumerable<int> GetTickets(int movieId, int TheaterId, int ShowId);
        public ActionResult BookTicket(int movieId, int TheaterId, int showId, int tickets);

        public Boolean bookingStats(int movieId, int TheaterId, int showId, int userId, int ticketsBooked);

        public ActionResult bookingSeat(int movieId, int TheaterId, int showId, int seatId);

        public IEnumerable<int> getSeats(int movieId, int TheaterId, int showId);

        public ActionResult getBookings(int movieId, int TheaterId, int showId, int userId, int seatId);
        public List<myBookingDTO> GetuserBookings(int userId);

    }
}
