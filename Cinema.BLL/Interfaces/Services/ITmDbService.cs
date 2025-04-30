using Cinema.BLL.DTOs.Movies;

namespace Cinema.BLL.Interfaces.Services;

public interface ITmDbService
{
    Task<IEnumerable<MovieDto>> SearchMoviesAsync(string query);
    Task<MovieCreateDto?> GetMovieForCreateAsync(int tmDbId);
}