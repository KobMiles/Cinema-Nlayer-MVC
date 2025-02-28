using Cinema.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.DAL.Configurations;

public class SeatConfiguration : IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder
            .Property(p => p.SeatRow)
            .IsRequired();

        builder
            .Property(p => p.SeatNumber)
            .IsRequired();

        builder
            .HasOne(p => p.Hall)
            .WithMany(h => h.Seats)
            .HasForeignKey(p => p.HallId);

        builder
            .HasMany(p => p.Tickets)
            .WithOne(t => t.Seat)
            .HasForeignKey(t => t.SeatId);

        builder
            .HasIndex(p => new { p.HallId, p.SeatRow, p.SeatNumber })
            .IsUnique();
    }
}