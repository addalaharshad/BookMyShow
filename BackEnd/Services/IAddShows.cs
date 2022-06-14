using Microsoft.AspNetCore.Mvc;

namespace BookMyShow_BE.Services
{
    public interface IAddShows
    {
        public ActionResult PostShow(int movieId, int theaterId, int showId);
    }
}
