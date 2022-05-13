using BookMyShow_BE.Models;
using Microsoft.AspNetCore.Mvc;
using PetaPoco;
using PetaPoco.Providers;
using AutoMapper;
using BookMyShow_BE.Services;
using BookMyShow_BE.Data_Models;

namespace BookMyShow_BE.Services
{
    public class Movies : IMovies
    {
        private readonly IDatabase db;
        private readonly AutoMapper.IMapper _mapper;
        public Movies(AutoMapper.IMapper mapper)
        {
            _mapper = mapper;
            db = DatabaseConfiguration.Build()
                     .UsingConnectionString("Data Source=.\\sqlexpress;Initial Catalog=BookMyShow;Integrated Security=True")
                     .UsingProvider<SqlSererMsDataDatabaseProvider>()
                     .UsingDefaultMapper<ConventionMapper>(m =>
                     {
                         m.InflectTableName = (inflector, s) => inflector.Pluralise(inflector.Underscore(s));
                         m.InflectColumnName = (inflector, s) => inflector.Underscore(s);
                     })
                     .Create();
        }
        public List<MovieDTO> GetMovies()
        {

            List<MovieDTO> result = new List<MovieDTO>();
            foreach (var a in db.Query<Movie>("SELECT * FROM Movies"))
            {
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
    }
}
