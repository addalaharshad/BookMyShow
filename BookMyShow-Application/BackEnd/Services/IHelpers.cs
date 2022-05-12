using BookMyShow_BE.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow_BE.Services
{
    public interface IHelpers
    {
        public Task<ActionResult<IEnumerable<Register>>> GetUsers();
    }
}
