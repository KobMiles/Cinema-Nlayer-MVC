using Cinema.BLL.DTOs.Halls;

namespace Cinema.BLL.DTOs.Seats;

public class SeatDetailsDto
{
    public int Id { get; set; }
    public int SeatRow { get; set; }
    public int SeatNumber { get; set; }

    public int HallId { get; set; }
    public HallDto Hall { get; set; } = null!;
}