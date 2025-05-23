﻿using Cinema.DAL.Data;
using Cinema.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace Cinema.WebApp.Extensions;

public static class IdentityServiceExtensions
{
    public static IServiceCollection AddCustomIdentityServices(
        this IServiceCollection services)
    {
        services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.MaxFailedAccessAttempts = 10;

                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<CinemaDbContext>()
            .AddDefaultTokenProviders();

        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.AccessDeniedPath = "/Account/AccessDenied";
            options.SlidingExpiration = true;

            options.ReturnUrlParameter = "returnUrl";
            options.Events.OnRedirectToLogin = context =>
            {
                context.Response.Redirect($"/Account/Login?returnUrl={Uri.EscapeDataString(context.Request.Path + context.Request.QueryString)}");
                return Task.CompletedTask;
            };
        });
        
        return services;
    }
}