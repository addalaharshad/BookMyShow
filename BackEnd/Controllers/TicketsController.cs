using BookMyShow_BE.Services;
using BookMyShow_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;
using PetaPoco.Providers;
using BookMyShow_BE.Data_Models;

namespace BookMyShow_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly BookMyShowContext _context;
        
        private readonly ITickets _tickets;
        public TicketsController(BookMyShowContext context, ITickets tickets)
        {
            _context = context;
            _tickets = tickets;
        }
        [HttpGet("{movieId}/{TheaterId}/{ShowId}")]
        public ActionResult<int> GetTickets(int movieId, int TheaterId, int ShowId)
        {
            return Ok(_tickets.GetTickets(movieId, TheaterId, ShowId));
        }


        [HttpGet("{movieId}/{TheaterId}/{showId}/{tickets}")]
        public ActionResult BookTicket(int movieId, int TheaterId, int showId, int tickets)
        {
            return Ok(_tickets.BookTicket(movieId, TheaterId, showId, tickets));

        }

        [HttpGet("{movieId}/{TheaterId}/{showId}/{userId}/{ticketsBooked}")]

        public ActionResult<Boolean> bookingStats(int movieId, int TheaterId, int showId,int userId,int ticketsBooked )
        {
            return Ok(_tickets.bookingStats(movieId, TheaterId, showId,userId,ticketsBooked));
        }

        [HttpGet("seats/{movieId}/{TheaterId}/{showId}/{seatId}")]

        public ActionResult bookingSeat(int movieId, int TheaterId, int showId, int seatId)
        {
            return Ok(_tickets.bookingSeat(movieId, TheaterId, showId, seatId));
        }

        [HttpGet("getseats/{movieId}/{TheaterId}/{showId}")]

        public ActionResult getSeats(int movieId, int TheaterId, int showId)
        {
            return Ok(_tickets.getSeats(movieId, TheaterId, showId));
        }

        [HttpGet("myBookings/{movieId}/{TheaterId}/{showId}/{userId}/{seatId}")]

        public ActionResult getBookings(int movieId, int TheaterId, int showId,int userId, int seatId)
        {
            return Ok(_tickets.getBookings(movieId, TheaterId, showId,userId,seatId));
        }

        [HttpGet("getmyBookings/{userId}")]

        public ActionResult GetuserBookings(int userId)
        {
            var res = _tickets.GetuserBookings(userId);
            return Ok(res);
        }

    }
}
