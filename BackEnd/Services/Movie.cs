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
    public class Movie : IMovies
    {
        private readonly IDatabase db;
        private readonly AutoMapper.IMapper _mapper;
        sharedDb sd = new sharedDb();
        public Movie(AutoMapper.IMapper mapper)
        {
            _mapper = mapper;
            db = sd.getDb();
        }
        public List<MovieDTO> GetMovies()
        {

            List<MovieDTO> result = new List<MovieDTO>();
            foreach (var a in db.Query<Models.Movies>("SELECT * FROM Movies"))
            {
                Console.WriteLine(a.MoviePath);
                result.Add(_mapper.Map<MovieDTO>(a));
            }
            return result;
        }
        public List<String> GetMovie(int id)
        {
            List<string> obj = new List<string>();
            obj.Add(db.SingleOrDefault<string>("select name from Movies where id=@0", id));
            return obj;
        }

        public ActionResult AddMovie(string name, string language, string moviePath)
        {
            var obj = new Models.Movies();
            obj.Name = name;
            obj.Language = language;
            obj.MoviePath = moviePath;

            db.Insert(obj);

            return null;
        }
    }
}
