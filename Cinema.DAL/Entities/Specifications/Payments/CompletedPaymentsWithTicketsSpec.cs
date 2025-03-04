using Ardalis.Specification;

namespace Cinema.DAL.Entities.Specifications.Payments;

public class CompletedPaymentsWithTicketsSpec : Specification<Payment>
{
    public CompletedPaymentsWithTicketsSpec()
    {
        Query.Where(p => p.PaymentStatus == PaymentStatus.Completed)
            .Include(p => p.Tickets);
    }
}