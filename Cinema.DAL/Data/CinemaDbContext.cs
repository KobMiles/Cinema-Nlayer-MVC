using Microsoft.EntityFrameworkCore;

namespace Cinema.DAL.Data;

public class CinemaDbContext : DbContext
{
    public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
        : base(options ?? throw new ArgumentNullException(nameof(options)))
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}