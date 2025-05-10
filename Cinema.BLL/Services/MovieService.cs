using AutoMapper;
using Cinema.BLL.DTOs.Movies;
using Cinema.BLL.Interfaces.Services;
using Cinema.DAL.Entities;
using Cinema.DAL.Entities.Specifications.Genres;
using Cinema.DAL.Entities.Specifications.Movies;
using Cinema.DAL.Interfaces.Repositories;

namespace Cinema.BLL.Services;

public class MovieService(IUnitOfWork unitOfWork, IMapper mapper) : IMovieService
{
    public async Task<IEnumerable<MovieDto>> GetMoviesWithActiveSessionsAsync()
    {
        var spec = new MoviesWithActiveSessionsSpecification();
        var movies = await unitOfWork.Movies.ListAsync(spec);

        return mapper.Map<IEnumerable<MovieDto>>(movies);
    }

    public async Task<MovieDetailsDto?> GetMovieDetailsAsync(int id)
    {
        var spec = new MovieByIdWithGenresAndSessionsSpec(id);
        var movie = await unitOfWork.Movies.FirstOrDefaultAsync(spec);

        if (movie == null)
            return null;

        return mapper.Map<MovieDetailsDto>(movie);
    }

    public async Task CreateAsync(MovieCreateDto dto)
    {
        var movie = mapper.Map<Movie>(dto);

        if (dto.GenreIds.Count != 0)
        {
            var genres = await unitOfWork.Genres
                .ListAsync(new GenresByIdsSpec(dto.GenreIds));

            foreach (var genre in genres)
            {
                movie.Genres.Add(genre);
            }

            var missingIds = dto.GenreIds.Except(genres.Select(g => g.Id));
            foreach (var id in missingIds)
            {
                var newGenre = new Genre
                {
                    Name = $"Genre_{id}"
                };
                await unitOfWork.Genres.AddAsync(newGenre);
                movie.Genres.Add(newGenre);
            }
        }

        await unitOfWork.Movies.AddAsync(movie);
        await unitOfWork.SaveAsync();
    }

}
