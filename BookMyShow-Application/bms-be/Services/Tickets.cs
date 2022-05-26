using BookMyShow_BE.Models;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;
using PetaPoco.Providers;
using BookMyShow_BE.Services.Shared_Db;
using System.Linq;

namespace BookMyShow_BE.Services
{
    public class Tickets : ITickets
    {
        private readonly IDatabase db;
        sharedDb sd = new sharedDb();
        private readonly BookMyShowContext _context;
        public Tickets(BookMyShowContext context)
        {
            db = sd.getDb();
            _context = context;
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

        public Boolean bookingStats(int movieId, int TheaterId, int showId, int userId, int ticketsBooked)
        {
            // db.EnableAutoSelect = false;
            int alreadyBooked = 0;
            IEnumerable<int> a = db.Query<int>("select ticketsBooked from bookings where userID=@0 and movieID=@1 and theaterID=@2 and showID=@3",userId,movieId,TheaterId,showId);
            if(a.Count()==0)
            {
                var obj = new Booking();
                obj.ShowId = showId;
                obj.TheaterId = TheaterId;
                obj.UserId = userId;
                obj.MovieId = movieId;
                obj.TicketsBooked = ticketsBooked;
                _context.Bookings.Add(obj);
                _context.SaveChanges();
            }
            else
            {
                foreach(var b in a)
                {
                    alreadyBooked = b;
                }
                if(alreadyBooked+ticketsBooked>6)
                {
                    return false;
                }
                db.Update<Booking>("SET ticketsBooked=ticketsBooked+@0 WHERE movieID=@1 and theaterID=@2 and showID=@3 and userID=@4", ticketsBooked, movieId, TheaterId, showId, userId);
            }
            return true;
        }
    }
}
