using Cinema.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DAL.Data;

public static class ModelBuilderExtensions
{
    public static void SeedGenres(this ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Genre>()
            .HasData(
            new Genre { Id = 1, Name = "Action" },
            new Genre { Id = 2, Name = "Comedy" },
            new Genre { Id = 3, Name = "Drama" }
        );
    }

    public static void SeedHalls(this ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Hall>()
            .HasData(
            new Hall { Id = 1 },
            new Hall { Id = 2 }
            );
    }

    public static void SeedSeats(this ModelBuilder modelBuilder)
    {
        const int totalHalls = 2;
        const int totalRows = 6;
        const int seatsPerRow = 6;

        var seats = new List<Seat>();
        int seatId = 1;

        for (int hallId = 1; hallId <= totalHalls; hallId++)
        {
            for (int row = 1; row <= totalRows; row++)
            {
                for (int seatNumber = 1; seatNumber <= seatsPerRow; seatNumber++)
                {
                    seats.Add(new Seat
                    {
                        Id = seatId++,
                        SeatRow = row,
                        SeatNumber = seatNumber,
                        HallId = hallId
                    });
                }
            }
        }
        modelBuilder
            .Entity<Seat>()
            .HasData(seats.ToArray());
    }


    public static void SeedMovies(this ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Movie>()
            .HasData(
            new Movie
            {
                Id = 1,
                Name = "Explosive Action",
                Description = "An adrenaline-filled action movie.",
                RatingScore = 4.5f,
                Duration = new TimeSpan(2, 0, 0),
                ReleaseDate = new DateTime(2023, 1, 1),
                PosterUrl = "https://example.com/explosive-action-poster.jpg",
                TrailerUrl = "https://example.com/explosive-action-trailer.mp4"
            },
            new Movie
            {
                Id = 2,
                Name = "Laugh Out Loud",
                Description = "A comedy that will make you laugh non-stop.",
                RatingScore = 4.0f,
                Duration = new TimeSpan(1, 30, 0),
                ReleaseDate = new DateTime(2022, 5, 15),
                PosterUrl = "https://example.com/laugh-out-loud-poster.jpg",
                TrailerUrl = "https://example.com/laugh-out-loud-trailer.mp4"
            },
            new Movie
            {
                Id = 3,
                Name = "Deep Emotions",
                Description = "A dramatic journey of love and loss.",
                RatingScore = 4.2f,
                Duration = new TimeSpan(1, 50, 0),
                ReleaseDate = new DateTime(2021, 8, 10),
                PosterUrl = "https://example.com/deep-emotions-poster.jpg",
                TrailerUrl = "https://example.com/deep-emotions-trailer.mp4"
            });
    }

    public static void SeedMovieGenres(this ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Movie>()
            .HasMany(m => m.Genres)
            .WithMany(g => g.Movies)
            .UsingEntity<Dictionary<string, object>>(
                "MovieGenre",
                j => j.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
                j => j.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                j =>
                {
                    j.HasKey("MovieId", "GenreId");
                    j.HasData(
                        new { MovieId = 1, GenreId = 1 },
                        new { MovieId = 2, GenreId = 2 },
                        new { MovieId = 3, GenreId = 3 }
                    );
                });
    }

    public static void SeedSessions(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Session>().HasData(
            new Session
            {
                Id = 1,
                MovieId = 1,
                HallId = 1,
                StartTime = new DateTime(2025, 06, 15, 18, 0, 0),
                TicketPrice = 12.50m
            },
            new Session
            {
                Id = 2,
                MovieId = 2,
                HallId = 2,
                StartTime = new DateTime(2025, 06, 16, 18, 0, 0),
                TicketPrice = 13.50m
            },
            new Session
            {
                Id = 3,
                MovieId = 3,
                HallId = 1,
                StartTime = new DateTime(2025, 06, 17, 18, 0, 0),
                TicketPrice = 16.50m
            }
        );
    }
}