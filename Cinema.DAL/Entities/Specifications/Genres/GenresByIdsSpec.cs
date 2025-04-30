using Ardalis.Specification;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Cinema.DAL.Entities.Specifications.Genres;

public sealed class GenresByIdsSpec : Specification<Genre>
{
    public GenresByIdsSpec(IEnumerable<int> ids)
    {
        Query.Where(g => ids.Contains(g.Id));
    }
}