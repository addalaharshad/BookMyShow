using BookMyShow_BE.Models;
using BookMyShow_BE.Data_Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow_BE.Services
{
    public interface ITheaters
    {
        public List<TheaterDTO> GetTheaters(int id);
        public IEnumerable<string> GetTheaterName(int id);

        public ActionResult PostTheater(string name, string loaction);
    }
}
