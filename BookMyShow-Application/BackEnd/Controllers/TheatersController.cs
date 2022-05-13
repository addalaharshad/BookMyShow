using BookMyShow_BE.Services;
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
        private readonly ITheaters _theater;
        public TheatersController(BookMyShowContext context, ITheaters theater)
        {
            _context = context;
            _theater = theater;
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
            var res = _theater.GetTheaters(id);
            return Ok(res);
        }


    }
}
