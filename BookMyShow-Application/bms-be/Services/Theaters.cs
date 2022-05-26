using BookMyShow_BE.Models;
using PetaPoco;
using PetaPoco.Providers;
using AutoMapper;
using BookMyShow_BE.Data_Models;
using BookMyShow_BE.Services.Shared_Db;

namespace BookMyShow_BE.Services
{
    public class Theaters : ITheaters
    {
        private readonly AutoMapper.IMapper _mapper;
        private readonly IDatabase db;
        sharedDb sd = new sharedDb();
        public Theaters(AutoMapper.IMapper mapper)
        {
            _mapper = mapper;
            db = sd.getDb();
        }
        public List<TheaterDTO> GetTheaters(int id)
        {
          
            var a = db.Query<Theater>("select distinct t.Id,t.Name from shows as s inner join Theaters as t on s.theaterID = T.Id where movieID = @0", id);
            List<TheaterDTO> theaters = new List<TheaterDTO>();
            foreach (var b in a)
            {
                theaters.Add(_mapper.Map<TheaterDTO>(b));
            }
            return theaters;
        }
    }
}
