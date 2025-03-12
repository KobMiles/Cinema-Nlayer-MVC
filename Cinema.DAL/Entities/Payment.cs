using Cinema.DAL.Entities.Enums;
using Cinema.DAL.Interfaces;

namespace Cinema.DAL.Entities;

public class Payment : IEntity
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }

    public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
}