namespace Cinema.BLL.DTOs.Sessions;

public class SessionDto
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int HallId { get; set; }
    public DateTime StartTime { get; set; }
    public decimal TicketPrice { get; set; }
}