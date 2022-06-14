using AutoMapper;
using BookMyShow_BE.Data_Models;
using BookMyShow_BE.Models;

namespace BookMyShow_BE.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Movies, MovieDTO>().ReverseMap();
            CreateMap<Theaters, TheaterDTO>().ReverseMap();
            CreateMap<Register, RegisterDTO>().ReverseMap();
            CreateMap<Userbooking,UserbookingDTO>().ReverseMap();
        }
    }
}
