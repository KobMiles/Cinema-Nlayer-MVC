using Cinema.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.DAL.Configurations;

public class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder
            .HasKey(s => s.Id);

        builder
            .Property(s => s.MovieId)
            .IsRequired();

        builder
            .Property(s => s.HallId)
            .IsRequired();

        builder
            .Property(s => s.StartTime)
            .IsRequired();

        builder
            .Property(s => s.TicketPrice)
            .HasPrecision(18, 2)
            .IsRequired();

        builder
            .HasOne(s => s.Movie)
            .WithMany(m => m.Sessions)
            .HasForeignKey(s => s.MovieId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(s => s.Hall)
            .WithMany(h => h.Sessions)
            .HasForeignKey(s => s.HallId);
    }
}