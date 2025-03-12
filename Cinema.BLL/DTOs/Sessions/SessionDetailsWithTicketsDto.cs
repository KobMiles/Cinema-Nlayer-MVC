using Cinema.BLL.DTOs.Halls;
using Cinema.BLL.DTOs.Movies;
using Cinema.BLL.DTOs.Tickets;

namespace Cinema.BLL.DTOs.Sessions;

public class SessionDetailsWithTicketsDto
{
    public int Id { get; set; }

    public int MovieId { get; set; }
    public MovieDto Movie { get; set; } = null!;

    public int HallId { get; set; }
    public HallDto Hall { get; set; } = null!;

    public DateTime StartTime { get; set; }
    public decimal TicketPrice { get; set; }

    public IReadOnlyCollection<TicketDto> Tickets { get; set; } = [];
}