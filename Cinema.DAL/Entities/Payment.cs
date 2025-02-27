using Cinema.DAL.Interfaces;

namespace Cinema.DAL.Entities;
public class Payment : IEntity
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string PaymentMethod { get; set; } = null!;

    public ICollection<Ticket> Tickets { get; set; } = [];
}