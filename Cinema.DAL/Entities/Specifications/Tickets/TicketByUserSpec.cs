using Ardalis.Specification;

namespace Cinema.DAL.Entities.Specifications.Tickets;

public class TicketByUserSpec : Specification<Ticket>
{
    public TicketByUserSpec(string userId)
    {
        Query.Where(t => t.UserId == userId)
            .Include(t => t.User)
            .Include(t => t.Seat)
            .Include(t => t.Session)
            .ThenInclude(s => s.Movie);
    }
}