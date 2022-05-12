using BookMyShow_BE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;
using PetaPoco.Providers;

namespace BookMyShow_BE.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TheatersController : ControllerBase
    {
        private readonly BookMyShowContext _context;
        private readonly IDatabase db;
        public TheatersController(BookMyShowContext context)
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

        [HttpGet("{id}")]
        public ActionResult GetTheaters(int id)
        {
            var a = db.Query<Theater>("select distinct t.Id,t.Name from shows as s inner join Theaters as t on s.theaterID = T.Id where movieID = @0", id);
            return Ok(a);
        }


    }
}
