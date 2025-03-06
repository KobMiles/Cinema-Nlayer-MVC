using Cinema.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Tests.DAL.Data;

public class CinemaDbContextTests
{
    [Fact]
    public void CanCreateCinemaDbContext_WhenOptionsProvided_ShouldNotBeNull()
    {
        var options = new DbContextOptionsBuilder<CinemaDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;

        using var dbContext = new CinemaDbContext(options);

        Assert.NotNull(dbContext);
    }

    [Fact]
    public void CanCreateCinemaDbContext_WhenOptionsNotProvided_ShouldThrowArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new CinemaDbContext(null!));
    }
}