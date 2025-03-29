using Ardalis.Specification;

namespace Cinema.DAL.Entities.Specifications.Movies;

public class MovieByIdWithGenresAndSessionsSpec : Specification<Movie>
{
    public MovieByIdWithGenresAndSessionsSpec(int id)
    {
        Query
            .Where(m => m.Id == id)
            .Include(m => m.Genres)
            .Include(m => m.Sessions);
    }
}