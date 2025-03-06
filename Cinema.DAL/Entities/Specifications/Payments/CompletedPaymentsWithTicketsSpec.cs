using Ardalis.Specification;
using Cinema.DAL.Entities.Enums;

namespace Cinema.DAL.Entities.Specifications.Payments;

public class CompletedPaymentsWithTicketsSpec : Specification<Payment>
{
    public CompletedPaymentsWithTicketsSpec()
    {
        Query.Where(p => p.PaymentStatus == PaymentStatus.Completed)
            .Include(p => p.Tickets);
    }
}