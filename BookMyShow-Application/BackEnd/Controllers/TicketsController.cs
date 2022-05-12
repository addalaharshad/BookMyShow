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

        public TicketsController(BookMyShowContext context)
        {
            _context = context;
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
            var a = db.Query<int>("select tickets from shows where theaterID = @0 and movieID=@1 and showID =@2", TheaterId, movieId, ShowId);
            return Ok(a);
        }

        [HttpGet("{movieId}/{TheaterId}/{showId}/{tickets}")]
        public ActionResult BookTicket(int movieId, int TheaterId, int showId, int tickets)
        {
            db.Update<Show>("SET tickets = tickets-@0 WHERE movieID=@1 and theaterID=@2 and showID=@3", tickets, movieId, TheaterId, showId);



            return Ok(null);
        }
    }
}
