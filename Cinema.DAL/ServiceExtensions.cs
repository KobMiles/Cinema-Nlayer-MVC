using Cinema.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.DAL;

public static class ServiceExtensions
{
    public static void AddDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<CinemaDbContext>(x =>
            x.UseSqlServer(connectionString));
    }
}