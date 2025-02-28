using Cinema.DAL.Interfaces;

namespace Cinema.DAL.Entities;
public enum PaymentMethod
{
    Card,
    Cash
}

public enum PaymentStatus
{
    Pending, 
    Completed,
    Cancelled
}

public class Payment : IEntity
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }

    public ICollection<Ticket> Tickets { get; set; } = [];
}