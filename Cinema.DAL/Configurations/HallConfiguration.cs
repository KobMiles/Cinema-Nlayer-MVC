using Cinema.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.DAL.Configurations;

public class HallConfiguration : IEntityTypeConfiguration<Hall>
{
    public void Configure(EntityTypeBuilder<Hall> builder)
    {
        builder
            .HasKey(h => h.Id);

        builder
            .HasMany(h => h.Sessions)
            .WithOne(s => s.Hall)
            .HasForeignKey(s => s.HallId);
    }
}