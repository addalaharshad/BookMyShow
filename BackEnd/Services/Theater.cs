using BookMyShow_BE.Models;
using PetaPoco;
using PetaPoco.Providers;
using AutoMapper;
using BookMyShow_BE.Data_Models;
using BookMyShow_BE.Services.Shared_Db;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow_BE.Services
{
    public class Theater : ITheaters
    {
        private readonly AutoMapper.IMapper _mapper;
        private readonly IDatabase db;
        sharedDb sd = new sharedDb();
        public Theater(AutoMapper.IMapper mapper)
        {
            _mapper = mapper;
            db = sd.getDb();
        }
        public List<TheaterDTO> GetTheaters(int id)
        {
          
            var a = db.Query<Models.Theaters>("select distinct t.Id,t.Name from shows as s inner join Theaters as t on s.theaterID = T.Id where movieID = @0", id);
            List<TheaterDTO> theaters = new List<TheaterDTO>();
            foreach (var b in a)
            {
                theaters.Add(_mapper.Map<TheaterDTO>(b));
            }
            return theaters;
        }

        public IEnumerable<string> GetTheaterName(int id)
        {
            var a= db.Query<string>("select Name from theaters where Id=@0", id);
            return a;
        }

        public ActionResult PostTheater(string name,string loaction)
        {
            var obj = new Models.Theaters();
            obj.Name = name;
            obj.Location = loaction;
            db.Insert(obj);

            return null;
        }
    }
}
