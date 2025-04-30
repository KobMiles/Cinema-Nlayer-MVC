using AutoMapper;
using Cinema.BLL.DTOs.Movies;
using Cinema.BLL.External.TmDb.DTOs;
using Cinema.BLL.Helpers.Converters;

namespace Cinema.BLL.Helpers;

public class TmDbProfile : Profile
{
    public TmDbProfile()
    {
        CreateMap<TmDbGenreDto, TmDbGenreDto>();

        CreateMap<TmDbMovieDetailsDto, MovieCreateDto>()
            .ForMember(d => d.Name,
                o => o.MapFrom(s => s.Title))

            .ForMember(d => d.Description, 
                o => o.MapFrom(s => s.Overview))

            .ForMember(d => d.RatingScore,
                o => o.MapFrom(s => s.VoteAverage))

            .ForMember(d => d.Duration, 
                o => o.ConvertUsing<RuntimeConverter, int?>(s => s.Runtime))

            .ForMember(d => d.ReleaseDate, 
                o => o.ConvertUsing<ReleaseDateConverter, string?>(s => s.ReleaseDate))

            .ForMember(d => d.PosterUrl,
                o => o.MapFrom(s => s.PosterUrl))

            .ForMember(d => d.TrailerUrl,
                o => o.MapFrom(s => s.TrailerUrl))

            .ForMember(d => d.GenreIds,
                o => o.MapFrom(s => s.Genres.Select(g => g.Id)));

        CreateMap<TmDbMovieSearchItemDto, MovieDto>()
            .ForMember(d => d.Id, 
                o => o.MapFrom(s => s.Id))

            .ForMember(d => d.Name, 
                o => o.MapFrom(s => s.Title))

            .ForMember(d => d.PosterUrl, 
                o => o.MapFrom(s => s.PosterUrl))

            .ForMember(d => d.Description, o => o.Ignore())
            .ForMember(d => d.RatingScore, o => o.Ignore())
            .ForMember(d => d.Duration, o => o.Ignore())
            .ForMember(d => d.ReleaseDate, o => o.Ignore())
            .ForMember(d => d.TrailerUrl, o => o.Ignore());
    }
}