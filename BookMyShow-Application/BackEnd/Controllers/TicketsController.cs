using BookMyShow_BE.Services;
using BookMyShow_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;
using PetaPoco.Providers;

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
    }
}
