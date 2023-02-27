using Microsoft.AspNetCore.Identity;
using MoviesAPI.Data.Dtos;
using MoviesAPI.Models;
using AutoMapper;

namespace MoviesAPI.Profiles
{
    public class MovieTeatherProfile : Profile
    {
        public MovieTeatherProfile()
        {
            CreateMap<CreateMovieTeatherDTO, MovieTeather>();

            /*
             * Realiza a leitura do dado cadastrado no banco de dados e mapeia a partir deste ponto a relação 1:1 entre as chaves das tabelas:
             * -MovieTheater,
             * -Addresses
             * Em seguida monta o obj Json com a informação do endereço do cinema cadastrado
             * 
             * Exemplo:
             {
                "id": 1,
                "name": "Cinema dos sem teto",
                "readAddressDto": {
                    "id": 1,
                    "street": "Rua das andorinhas",
                    "number": 1084
                }
             }
             */
            CreateMap<MovieTeather, ReadMovieTeatherDTO>()
                .ForMember(movieTheaterDto => movieTheaterDto.Address,
                           opt => opt.MapFrom(movieTheater => movieTheater.Address))
                .ForMember(movieTheaterDto => movieTheaterDto.Sessions,
                           opt => opt.MapFrom(movieTheater => movieTheater.Sessions));

            CreateMap<UpdateMovieTeatherDTO, MovieTeather>();
        }
    }
}
