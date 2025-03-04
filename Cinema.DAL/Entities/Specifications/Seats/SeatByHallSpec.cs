using Ardalis.Specification;

namespace Cinema.DAL.Entities.Specifications.Seats;

public class SeatByHallSpec : Specification<Seat>
{
    public SeatByHallSpec(int hallId)
    {
        Query.Where(s => s.HallId == hallId)
            .Include(s => s.Hall);
    }
}