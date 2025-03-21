using Cinema.BLL.DTOs.Movies;
using Cinema.DAL.Interfaces.Repositories;

namespace Cinema.BLL.Interfaces.Services;

public interface IMovieService
{
    Task<IEnumerable<MovieDto>> GetMoviesWithActiveSessionsAsync();
}
