using Cinema.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.DAL.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder
            .HasKey(t => t.Id);

        builder
            .Property(t => t.TicketNumber)
            .HasMaxLength(150)
            .IsRequired();

        builder
            .HasIndex(t => t.TicketNumber)
            .IsUnique();

        builder
            .HasOne(t => t.Session)
            .WithMany(s => s.Tickets)
            .HasForeignKey(t => t.SessionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(t => t.Payment)
            .WithMany(p => p.Tickets)
            .HasForeignKey(t => t.PaymentId);

        builder
            .HasOne(t => t.Seat)
            .WithMany(p => p.Tickets)
            .HasForeignKey(t => t.SeatId);

        builder
            .Property(t => t.UserId)
            .HasMaxLength(450)
            .IsRequired();

        builder
            .HasOne(t => t.User)
            .WithMany(u => u.Tickets)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}