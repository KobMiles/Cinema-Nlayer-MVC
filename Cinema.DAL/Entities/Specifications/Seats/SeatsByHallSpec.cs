using Ardalis.Specification;

namespace Cinema.DAL.Entities.Specifications.Seats;

public sealed class SeatsByHallSpec : Specification<Seat>
{
    public SeatsByHallSpec(int hallId)
    {
        Query
            .Where(s => s.HallId == hallId);
    }
}