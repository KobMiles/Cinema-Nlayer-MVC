using Cinema.DAL.Interfaces;

namespace Cinema.DAL.Entities;

public class Seat : IEntity
{
    public int Id { get; set; }
    public int SeatRow { get; set; }
    public int SeatNumber { get; set; }

    public int HallId { get; set; }
    public Hall Hall { get; set; } = null!;

    public ICollection<Ticket> Tickets { get; set; } = [];
}