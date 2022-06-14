using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookMyShow_BE.Models;
using BookMyShow_BE.Services;

namespace BookMyShow_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddshowsController : ControllerBase
    {
        private readonly BookMyShowContext _context;
        private readonly IAddShows _addShows;

        public AddshowsController(BookMyShowContext context , IAddShows addshows)
        {
            _context = context;
            _addShows = addshows;
        }

        // GET: api/Addshows
        [HttpGet]

        public IActionResult PostShow(int movieId, int theaterId, int showId)
        {
            var res = _addShows.PostShow(movieId,theaterId,showId);
            return Ok(res);
        }
    }
}
