using BookMyShow_BE.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow_BE.Services
{
    public class Helpers:IHelpers
    {
        private readonly BookMyShowContext _context;

        public Helpers(BookMyShowContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Register>>> GetUsers()
        {
            return _context.Registers.ToList();
        }
    }
}
