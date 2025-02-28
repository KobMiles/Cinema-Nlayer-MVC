using Cinema.DAL.Interfaces;

namespace Cinema.DAL.Entities;

public class Ticket : IEntity
{
    public int Id { get; set; }

    public string TicketNumber { get; set; } = null!;

    public int SessionId { get; set; }
    public Session Session { get; set; } = null!;

    public int PaymentId { get; set; }
    public Payment Payment { get; set; } = null!;

    public int SeatId { get; set; }
    public Seat Seat { get; set; } = null!;

    public string UserId { get; set; } = null!;
    public User User { get; set; } = null!;
}