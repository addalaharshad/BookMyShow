using BookMyShow_BE.Models;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;
using PetaPoco.Providers;
using AutoMapper;
using BookMyShow_BE.Services;
using BookMyShow_BE.Data_Models;
using BookMyShow_BE.Services.Shared_Db;

namespace BookMyShow_BE.Services
{
    public class AddShow:IAddShows
    {
        private readonly IDatabase db;
        private readonly AutoMapper.IMapper _mapper;
        sharedDb sd = new sharedDb();
        public AddShow(AutoMapper.IMapper mapper)
        {
            _mapper = mapper;
            db = sd.getDb();
        }

        public ActionResult PostShow(int movieId,int theaterId,int showId)
        {
            var obj = new Addshows();
            obj.ShowId = showId;
            obj.MovieId = movieId;  
            obj.TheaterId = theaterId;
            db.Insert(obj);

            return null;
        }
    }
}
