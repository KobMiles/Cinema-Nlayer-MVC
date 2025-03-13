using Cinema.BLL.DTOs.Tickets;
using Cinema.DAL.Entities.Enums;

namespace Cinema.BLL.DTOs.Payments;

public class PaymentDetailsDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }

    public IReadOnlyCollection<TicketDto> Tickets { get; set; } = [];
}