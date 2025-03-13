using Cinema.BLL.DTOs.Seats;
using Cinema.BLL.DTOs.Sessions;

namespace Cinema.BLL.DTOs.Halls;

public class HallDetailsDto
{
    public int Id { get; set; }

    public IReadOnlyCollection<SessionDto> Sessions { get; set; } = [];
    public IReadOnlyCollection<SeatDto> Seats { get; set; } = [];
}