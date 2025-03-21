namespace Cinema.BLL.DTOs.Sessions;

public class SessionCreateDto
{
    public int MovieId { get; set; }
    public int HallId { get; set; }
    public DateTime StartTime { get; set; }
    public decimal TicketPrice { get; set; }
}