using AutoMapper;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class MovieProfile: Profile
    {
        public MovieProfile()
        {
            //Create Automap dto
            CreateMap<CreateMovieDTO, Filme>();
            CreateMap<Filme, CreateMovieDTO>()
                 .ForMember(movieDto => movieDto.Sessions,
                           opt => opt.MapFrom(movie => movie.Sessions));
        }
    }
}
