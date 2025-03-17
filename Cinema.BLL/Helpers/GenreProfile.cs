using AutoMapper;
using Cinema.BLL.DTOs.Genres;
using Cinema.DAL.Entities;

namespace Cinema.BLL.Helpers;

public class GenreProfile : Profile
{
    public GenreProfile()
    {
        CreateMap<Genre, GenreDto>();

        CreateMap<Genre, GenreDetailsDto>();
    }
}