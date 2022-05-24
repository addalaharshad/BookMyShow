

using Microsoft.AspNetCore.Mvc;

namespace BookMyShow_BE.Services
{
    public interface ITickets
    {
        public IEnumerable<int> GetTickets(int movieId, int TheaterId, int ShowId);
        public ActionResult BookTicket(int movieId, int TheaterId, int showId, int tickets);
    }
}
