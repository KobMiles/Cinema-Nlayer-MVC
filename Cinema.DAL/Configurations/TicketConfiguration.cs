using Cinema.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.DAL.Configurations;

public class TicketConfiguration
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder
            .HasKey(t => t.Id);

        builder
            .HasOne(t => t.Session)
            .WithMany(s => s.Tickets)
            .HasForeignKey(t => t.SessionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(t => t.Payment)
            .WithMany(p => p.Tickets)
            .HasForeignKey(t => t.PaymentId);

        builder
            .HasOne(t => t.Seat)
            .WithMany(p => p.Tickets)
            .HasForeignKey(t => t.SeatId);

        builder
            .HasOne(t => t.User)
            .WithMany(u => u.Tickets)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}