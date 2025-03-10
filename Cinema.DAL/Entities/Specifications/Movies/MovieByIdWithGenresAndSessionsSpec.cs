using Ardalis.Specification;

namespace Cinema.DAL.Entities.Specifications.Movies;

public class MovieByIdWithGenresAndSessionsSpec : Specification<Movie>
{
    public MovieByIdWithGenresAndSessionsSpec(int movieId)
    {
        Query.Where(m => m.Id == movieId);

        Query.Include(m => m.Genres)
            .Include(m => m.Sessions);
    }
}