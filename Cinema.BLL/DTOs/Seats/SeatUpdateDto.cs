namespace Cinema.BLL.DTOs.Seats;

public class SeatUpdateDto
{
    public int Id { get; set; }
    public int SeatRow { get; set; }
    public int SeatNumber { get; set; }
    public int HallId { get; set; }
}