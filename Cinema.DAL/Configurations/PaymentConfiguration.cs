using Cinema.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.DAL.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder
            .Property(p => p.Amount)
            .HasPrecision(18, 2)
            .IsRequired();

        builder
            .Property(p => p.PaymentDate)
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();

        builder
            .Property(p => p.PaymentMethod)
            .HasConversion<string>()
            .IsRequired();

        builder
            .Property(p => p.PaymentStatus)
            .HasConversion<string>()
            .IsRequired();
    }
}