using BookMyShow_BE.Models;
using BookMyShow_BE.Data_Models;

namespace BookMyShow_BE.Services
{
    public interface ITheaters
    {
        public List<TheaterDTO> GetTheaters(int id);
    }
}
