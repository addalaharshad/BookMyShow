using BookMyShow_BE.Models;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;
using PetaPoco.Providers;
using BookMyShow_BE.Services.Shared_Db;

namespace BookMyShow_BE.Services
{
    public class Tickets : ITickets
    {
        private readonly IDatabase db;
        sharedDb sd = new sharedDb();
        public Tickets()
        {
            db = sd.getDb();
        }
        public IEnumerable<int> GetTickets(int movieId, int TheaterId, int ShowId)
        {
            var a = db.Query<int>("select tickets from shows where theaterID = @0 and movieID=@1 and showID =@2", TheaterId, movieId, ShowId);
            return a;
        }
        public ActionResult BookTicket(int movieId, int TheaterId, int showId, int tickets)
        {
            db.Update<Show>("SET tickets = tickets-@0 WHERE movieID=@1 and theaterID=@2 and showID=@3", tickets, movieId, TheaterId, showId);

            return null;
        }
    }
}
