using Ardalis.Specification;

namespace Cinema.DAL.Entities.Specifications.Sessions;

public sealed class SessionsWithMovieAndHallSpecification : Specification<Session>
{
    public SessionsWithMovieAndHallSpecification()
    {
        Query
            .Include(s => s.Movie)
            .Include(s => s.Hall);
    }
}