namespace Cinema.BLL.DTOs.Tickets;

public class TicketCreateDto
{
    public int SessionId { get; set; }
    public int PaymentId { get; set; }
    public int SeatId { get; set; }
    public string UserId { get; set; } = null!;
}