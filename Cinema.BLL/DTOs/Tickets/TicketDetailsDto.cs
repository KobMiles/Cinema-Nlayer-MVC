using Cinema.BLL.DTOs.Payments;
using Cinema.BLL.DTOs.Seats;
using Cinema.BLL.DTOs.Sessions;
using Cinema.DAL.Entities;

namespace Cinema.BLL.DTOs.Tickets;

public class TicketDetailsDto
{
    public int Id { get; set; }
    public string TicketNumber { get; set; } = null!;

    public int SessionId { get; set; }
    public SessionDto Session { get; set; } = null!;

    public int PaymentId { get; set; }
    public PaymentDto Payment { get; set; } = null!;

    public int SeatId { get; set; }
    public SeatDto Seat { get; set; } = null!;

    public string UserId { get; set; } = null!;
    public User User { get; set; } = null!;
}