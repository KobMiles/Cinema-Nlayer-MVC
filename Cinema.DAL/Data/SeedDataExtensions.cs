﻿using Cinema.DAL.Entities;
using Microsoft.AspNetCore.Identity;
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

        var seats = Enumerable.Range(1, totalHalls)
            .SelectMany(hallId => Enumerable.Range(1, totalRows)
                .SelectMany(row => Enumerable.Range(1, seatsPerRow)
                    .Select(seatNumber => new Seat
                    {
                        Id = ((hallId - 1) * totalRows * seatsPerRow) + ((row - 1) * seatsPerRow) + seatNumber,
                        SeatRow = row,
                        SeatNumber = seatNumber,
                        HallId = hallId
                    })))
            .ToArray();

        modelBuilder
            .Entity<Seat>()
            .HasData(seats);
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
    public static void SeedIdentity(this ModelBuilder modelBuilder)
    {
        const string adminRoleId = "8F2D4A1E-3C4B-4B6E-9F8A-1234567890AB";
        const string userRoleId = "7E1C3B2A-4D5E-6F7A-8B9C-0987654321CD";
        const string adminUserId = "5A6B7C8D-9E0F-1A2B-3C4D-5E6F7A8B9C0D";

        modelBuilder.Entity<Role>(b =>
        {
            b.HasData(
                new Role
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new Role
                {
                    Id = userRoleId,
                    Name = "User",
                    NormalizedName = "USER"
                }
            );
        });

        var hasher = new PasswordHasher<User>();
        var admin = new User
        {
            Id = adminUserId,
            UserName = "admin@cinema.com",
            NormalizedUserName = "ADMIN@CINEMA.COM",
            Email = "admin@cinema.com",
            NormalizedEmail = "ADMIN@CINEMA.COM",
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString("D")
        };
        admin.PasswordHash = hasher.HashPassword(admin, "Admin123!");

        modelBuilder.Entity<User>(b =>
        {
            b.HasData(admin);
        });

        modelBuilder.Entity<IdentityUserRole<string>>(b =>
        {
            b.HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminUserId
            });
        });
    }
}