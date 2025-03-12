using Cinema.DAL.Interfaces;

namespace Cinema.DAL.Entities;

public class Hall : IEntity
{
    public int Id { get; set; }

    public ICollection<Session> Sessions { get; set; } = new HashSet<Session>();
    public ICollection<Seat> Seats { get; set; } = new HashSet<Seat>();
}
