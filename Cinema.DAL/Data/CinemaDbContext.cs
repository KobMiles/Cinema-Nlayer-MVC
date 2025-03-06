using Cinema.DAL.Configurations;
using Cinema.DAL.Configurations.Identity;
using Cinema.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DAL.Data;

public class CinemaDbContext : IdentityDbContext<User, Role, string>
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Hall> Halls { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Payment> Payments { get; set; }

    public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
        : base(options ?? throw new ArgumentNullException(nameof(options)))
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new MovieConfiguration());
        modelBuilder.ApplyConfiguration(new GenreConfiguration());
        modelBuilder.ApplyConfiguration(new HallConfiguration());
        modelBuilder.ApplyConfiguration(new SessionConfiguration());
        modelBuilder.ApplyConfiguration(new SeatConfiguration());
        modelBuilder.ApplyConfiguration(new TicketConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserClaimConfiguration());
        modelBuilder.ApplyConfiguration(new UserLoginConfiguration());
        modelBuilder.ApplyConfiguration(new UserTokenConfiguration());
        modelBuilder.ApplyConfiguration(new RoleClaimConfiguration());

        modelBuilder.SeedGenres();
        modelBuilder.SeedHalls();
        modelBuilder.SeedSeats();
        modelBuilder.SeedMovies();
        modelBuilder.SeedMovieGenres();
        modelBuilder.SeedSessions();
    }
}