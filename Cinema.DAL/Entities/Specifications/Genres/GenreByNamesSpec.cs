using Ardalis.Specification;

namespace Cinema.DAL.Entities.Specifications.Genres;

public sealed class GenreByNamesSpec : Specification<Genre>
{
    public GenreByNamesSpec(IEnumerable<string> names)
    {
        Query.Where(g => names.Contains(g.Name));
    }
}