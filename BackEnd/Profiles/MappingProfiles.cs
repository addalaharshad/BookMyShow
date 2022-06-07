using AutoMapper;
using BookMyShow_BE.Data_Models;
using BookMyShow_BE.Models;

namespace BookMyShow_BE.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<Theater, TheaterDTO>().ReverseMap();
            CreateMap<Register, RegisterDTO>().ReverseMap();
            CreateMap<MyBooking,myBookingDTO>().ReverseMap();
        }
    }
}
