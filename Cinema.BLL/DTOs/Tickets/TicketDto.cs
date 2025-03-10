namespace Cinema.BLL.DTOs.Tickets;

public class TicketDto
{
    public int Id { get; set; }
    public string TicketNumber { get; set; } = null!;
    public int SessionId { get; set; }
    public int PaymentId { get; set; }
    public int SeatId { get; set; }
    public string UserId { get; set; } = null!;
}