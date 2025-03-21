using Cinema.DAL.Entities.Enums;

namespace Cinema.BLL.DTOs.Payments;

public class PaymentUpdateDto
{
    public int Id { get; set; }

    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
}