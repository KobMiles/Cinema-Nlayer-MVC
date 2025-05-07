using Cinema.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cinema.DAL.Configurations;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder
            .HasKey(m => m.Id);

        builder
            .Property(m => m.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(m => m.Description)
            .HasMaxLength(1000)
            .IsRequired(false);

        builder
            .Property(m => m.RatingScore)
            .IsRequired();

        builder
            .Property(m => m.Duration)
            .HasColumnType("time")
            .IsRequired();

        builder
            .Property(m => m.ReleaseDate)
            .IsRequired(false);

        builder
            .Property(m => m.PosterUrl)
            .HasColumnType("TEXT")
            .HasMaxLength(300)
            .IsRequired();

        builder
            .Property(m => m.TrailerUrl)
            .HasColumnType("TEXT")
            .HasMaxLength(300)
            .IsRequired();

        builder
            .HasMany(m => m.Genres)
            .WithMany(g => g.Movies);

        builder
            .ToTable(t => t
            .HasCheckConstraint("CK_Movie_Rating", "RatingScore BETWEEN 0.0 AND 10.0"));
    }
}