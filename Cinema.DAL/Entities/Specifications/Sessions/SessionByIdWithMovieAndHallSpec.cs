using Ardalis.Specification;

namespace Cinema.DAL.Entities.Specifications.Sessions;

public class SessionByIdWithMovieAndHallSpec : Specification<Session>
{
    public SessionByIdWithMovieAndHallSpec(int sessionId)
    {
        Query.Where(s => s.Id == sessionId)
            .Include(s => s.Movie)
            .Include(s => s.Hall);
    }
}