using AutoMapper;
using Cinema.BLL.DTOs.Movies;
using Cinema.BLL.Interfaces.Services;
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
}