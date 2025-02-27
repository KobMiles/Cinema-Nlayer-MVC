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
            .IsRequired();

        builder
            .Property(p => p.Date)
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();

        builder
            .Property(p => p.PaymentMethod)
            .HasMaxLength(60)
            .IsRequired();
    }
}