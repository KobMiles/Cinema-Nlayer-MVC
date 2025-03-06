using Ardalis.Specification;

namespace Cinema.DAL.Entities.Specifications.Genres;

public class GenreByIdWithMoviesSpec : Specification<Genre>
{
    public GenreByIdWithMoviesSpec(int genreId)
    {
        Query.Where(g => g.Id == genreId)
            .Include(g => g.Movies);
    }
}