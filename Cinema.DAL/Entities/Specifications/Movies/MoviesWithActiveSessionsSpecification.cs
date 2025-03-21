using Ardalis.Specification;

namespace Cinema.DAL.Entities.Specifications.Movies;

public class MoviesWithActiveSessionsSpecification : Specification<Movie>
{
    public MoviesWithActiveSessionsSpecification()
    {
        Query
            .Where(movie => movie.Sessions.Any(s => s.StartTime >= DateTime.Now))
            .Include(movie => movie.Sessions);
    }
}