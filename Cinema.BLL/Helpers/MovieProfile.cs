using AutoMapper;
using Cinema.BLL.DTOs.Movies;
using Cinema.DAL.Entities;

namespace Cinema.BLL.Helpers;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<Movie, MovieDto>();
        CreateMap<Movie, MovieDetailsDto>();

        CreateMap<MovieCreateDto, Movie>()
            .ForMember(m => m.Genres, o => o.Ignore());
        CreateMap<MovieUpdateDto, Movie>();
    }
}