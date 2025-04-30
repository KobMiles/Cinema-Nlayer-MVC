using System.Net.Http.Headers;
using Cinema.BLL.External.TmDb;
using Cinema.BLL.External.TmDb.Interfaces;
using Cinema.BLL.Interfaces.Services;
using Cinema.BLL.Services;
using Cinema.BLL.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cinema.BLL;

public static class ServiceExtensions
{
    public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITmDbService, TmDbService>();

        return services;
    }
    
    public static IServiceCollection AddFluentValidators(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<UserRegisterDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<MovieCreateDtoValidator>();

        return services;
    }

    public static IServiceCollection AddTmDbClient(
        this IServiceCollection services, IConfiguration cfg)
    {
        services.Configure<TmDbOptions>(cfg.GetSection(TmDbOptions.SectionName));

        services.AddHttpClient<ITmDbClient, TmDbClient>()
            .ConfigureHttpClient((sp, http) =>
            {
                var opt = sp.GetRequiredService<IOptionsMonitor<TmDbOptions>>()
                    .CurrentValue;
                http.BaseAddress = new Uri(opt.BaseUrl);
                http.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

        return services;
    }
}