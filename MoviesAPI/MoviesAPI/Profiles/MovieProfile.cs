using AutoMapper;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;

namespace MoviesAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            //Create Automap dto
            CreateMap<CreateMovieDTO, Filme>();
            CreateMap<UpdateMovieDTO, Filme>();
            CreateMap<Filme, UpdateMovieDTO>();
            CreateMap<Filme, ReadMovieDTO>()
                 .ForMember(movieDto => movieDto.Sessions,
                           opt => opt.MapFrom(movie => movie.Sessions));
        }
    }
}
