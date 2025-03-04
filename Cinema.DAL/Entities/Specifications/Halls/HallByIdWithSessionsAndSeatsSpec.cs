using Ardalis.Specification;

namespace Cinema.DAL.Entities.Specifications.Halls;

public class HallByIdWithSessionsAndSeatsSpec : Specification<Hall>
{
    public HallByIdWithSessionsAndSeatsSpec(int hallId)
    {
        Query.Where(h => h.Id == hallId)
            .Include(h => h.Sessions)
            .Include(h => h.Seats);
    }
}