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
        private readonly IDatabase db;
        private readonly ITickets _tickets;
        public TicketsController(BookMyShowContext context, ITickets tickets)
        {
            _context = context;
            _tickets = tickets;
            db = DatabaseConfiguration.Build()
                    .UsingConnectionString("Data Source=.\\sqlexpress;Initial Catalog=BookMyShow;Integrated Security=True")
                    .UsingProvider<SqlSererMsDataDatabaseProvider>()
                    .UsingDefaultMapper<ConventionMapper>(m =>
                    {
                        m.InflectTableName = (inflector, s) => inflector.Pluralise(inflector.Underscore(s));
                        m.InflectColumnName = (inflector, s) => inflector.Underscore(s);
                    })
                    .Create();
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
