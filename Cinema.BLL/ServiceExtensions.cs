using Cinema.BLL.Interfaces.Services;
using Cinema.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cinema.BLL;

public static class ServiceExtensions
{
    public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<IMovieService, MovieService>();
        return services;
    }
}