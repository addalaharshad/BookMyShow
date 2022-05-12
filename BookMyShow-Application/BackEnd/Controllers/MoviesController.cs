using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookMyShow_BE.Models;
using PetaPoco;
using PetaPoco.Providers;

namespace BookMyShow_BE.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly BookMyShowContext _context;
        private readonly IDatabase db = DatabaseConfiguration.Build()
                     .UsingConnectionString("Data Source=.\\sqlexpress;Initial Catalog=BookMyShow;Integrated Security=True")
                     .UsingProvider<SqlSererMsDataDatabaseProvider>()
                     .UsingDefaultMapper<ConventionMapper>(m =>
                     {
                         m.InflectTableName = (inflector, s) => inflector.Pluralise(inflector.Underscore(s));
                         m.InflectColumnName = (inflector, s) => inflector.Underscore(s);
                     })
                     .Create();
        public MoviesController(BookMyShowContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetMovies()
        {
            List<Movie> result = new List<Movie>();
            foreach (var a in db.Query<Movie>("SELECT * FROM Movies"))
            {
               // Console.WriteLine(a.Id);
                result.Add(a);
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            List<string> obj = new List<string>();
            var a = db.SingleOrDefault<string>("select name from Movies where id=@0", id);
            obj.Add(a);
            return Ok(obj);

        }
    }
}
