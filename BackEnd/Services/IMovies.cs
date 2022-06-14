using BookMyShow_BE.Models;
using Microsoft.AspNetCore.Mvc;
using BookMyShow_BE.Data_Models;

namespace BookMyShow_BE.Services
{
    public interface IMovies
    {
        public List<MovieDTO> GetMovies();
        public List<String> GetMovie(int id);

        public ActionResult AddMovie(string name, string language, string moviePath);

    }
}
