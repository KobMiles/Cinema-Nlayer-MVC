using Cinema.DAL.Entities.Enums;

namespace Cinema.BLL.DTOs.Payments;

public class PaymentCreateDto
{
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}