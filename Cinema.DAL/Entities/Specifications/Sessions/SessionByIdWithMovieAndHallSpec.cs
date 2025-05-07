using Ardalis.Specification;

namespace Cinema.DAL.Entities.Specifications.Sessions;

public sealed class SessionByIdWithMovieAndHallSpec : Specification<Session>
{
    public SessionByIdWithMovieAndHallSpec(int sessionId, bool includeTickets = false)
    {
        Query
            .Where(s => s.Id == sessionId)
            .Include(s => s.Movie)
            .Include(s => s.Hall);


        if (includeTickets)
            Query.Include(s => s.Tickets);
    }
}