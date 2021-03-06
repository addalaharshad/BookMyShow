using BookMyShow_BE.Models;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;
using PetaPoco.Providers;
using BookMyShow_BE.Services.Shared_Db;
using System.Linq;
using BookMyShow_BE.Data_Models;

namespace BookMyShow_BE.Services
{
    public class Tickets : ITickets
    {
        private readonly IDatabase db;
        sharedDb sd = new sharedDb();
        private readonly BookMyShowContext _context;
        private readonly AutoMapper.IMapper _mapper;
        public Tickets(BookMyShowContext context, AutoMapper.IMapper mapper)
        {
            db = sd.getDb();
            _context = context;
            _mapper=mapper;
        }
        public IEnumerable<int> GetTickets(int movieId, int TheaterId, int ShowId)
        {
            var a = db.Query<int>("select tickets from shows where theaterID = @0 and movieID=@1 and showID =@2", TheaterId, movieId, ShowId);
            return a;
        }

        public ActionResult BookTicket(int movieId, int TheaterId, int showId, int tickets)
        {
            db.Update<Shows>("SET tickets = tickets-@0 WHERE movieID=@1 and theaterID=@2 and showID=@3", tickets, movieId, TheaterId, showId);

            return null;
        }

        public Boolean bookingStats(int movieId, int TheaterId, int showId, int userId, int ticketsBooked)
        {
            // db.EnableAutoSelect = false;
            int alreadyBooked = 0;
            IEnumerable<int> a = db.Query<int>("select ticketsBooked from bookings where userID=@0 and movieID=@1 and theaterID=@2 and showID=@3",userId,movieId,TheaterId,showId);
            if(a.Count()==0)
            {
                var obj = new Bookings();
                obj.ShowId = showId;
                obj.TheaterId = TheaterId;
                obj.UserId = userId;
                obj.MovieId = movieId;
                obj.TicketsBooked = ticketsBooked;
                //_context.Bookings.Add(obj);
               // _context.SaveChanges();
               db.Insert(obj);
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
                db.Update<Bookings>("SET ticketsBooked=ticketsBooked+@0 WHERE movieID=@1 and theaterID=@2 and showID=@3 and userID=@4", ticketsBooked, movieId, TheaterId, showId, userId);
            }
            return true;
        }

        public ActionResult bookingSeat(int movieId, int TheaterId, int showId, int seatId)
        {
            var obj = new Seats();
            obj.ShowId = showId;
            obj.TheaterId = TheaterId;
            obj.MovieId = movieId;
            obj.SeatId = seatId;
            // _context.Seats.Add(obj);
            // _context.SaveChanges();
            db.Insert(obj);
            //return _context.Seats.ToList();
            return null;
        }

        public IEnumerable<int> getSeats(int movieId, int TheaterId, int showId)
        {
            var a = db.Query<int>("select seatID from seats where theaterID = @0 and movieID=@1 and showID =@2", TheaterId, movieId, showId);
            return a;
        }

        public ActionResult getBookings(int movieId, int TheaterId, int showId,int userId,int seatId)
        {
            var obj = new Userbooking();
            obj.ShowId = showId;
            obj.TheaterId= TheaterId;
            obj.MovieId= movieId;
            obj.SeatId= seatId; 
            obj.UserId = userId;
            // _context.Userbookings.Add(obj);
            // _context.SaveChanges();
            db.Insert(obj);

            return null;
        }

        public List<UserbookingDTO> GetuserBookings(int userId)
        {

            var a = db.Query<Userbooking>("select movieID,theaterID,showID,seatID from userbookings where userID =@0", userId);
           // Console.WriteLine(a);
            List<UserbookingDTO> book = new List<UserbookingDTO>();
            foreach (var b in a)
            {
                book.Add(_mapper.Map<UserbookingDTO>(b));
            }
            Console.WriteLine(book);
            return book;
        }
    }
}
