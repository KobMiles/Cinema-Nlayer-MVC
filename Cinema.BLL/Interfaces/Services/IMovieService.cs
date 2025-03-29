using Cinema.BLL.DTOs.Movies;

namespace Cinema.BLL.Interfaces.Services;

public interface IMovieService
{
    Task<IEnumerable<MovieDto>> GetMoviesWithActiveSessionsAsync();
    Task<MovieDetailsDto?> GetMovieDetailsAsync(int movieId);
}