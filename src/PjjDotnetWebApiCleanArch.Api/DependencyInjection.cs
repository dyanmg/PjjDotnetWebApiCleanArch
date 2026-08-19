using Microsoft.AspNetCore.Mvc.Authorization;
using PjjDotnetWebApiCleanArch.Api.ExceptionHandlers;
using PjjDotnetWebApiCleanArch.Api.Extensions;
using PjjDotnetWebApiCleanArch.Api.Filters;
using PjjDotnetWebApiCleanArch.Domain.Entities;
using Serilog;

namespace PjjDotnetWebApiCleanArch.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services,
        IConfiguration configuration,
        IHostEnvironment environment)
    {
        services.AddControllers(c =>
        {
            c.Filters.Add<WrapResponseFilter>();

            // Jika bukan staging, maka tambahkan otorisasi global
            // Jika staging dan DisableGlobalAuthorize = true, maka tidak perlu otorisasi global
            if (environment.IsProduction()
                || configuration["DisableGlobalAuthorize"] != "true")
            {
                // Otorisasi global, semua endpoint akan memerlukan otorisasi
                c.Filters.Add(new AuthorizeFilter());
            }
        });
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        services.AddOpenApi();
        services.RegisterSwagger();
        services.AddHttpContextAccessor();
        services.AddExceptionHandler<GlobalExceptionHandlers>();
        services.AddIdentityApiEndpoints<Pegawai>();

        services.AddAuthorizationBuilder()
            .AddPolicy("SupervisorOnly", policy => policy.RequireClaim("jabatan", "Supervisor"));

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        return services;
    }

    public static IHostBuilder AddPresentationLogging(this IHostBuilder host)
    {
        host.UseSerilog((context, configuration) =>
        {
            configuration.ReadFrom.Configuration(context.Configuration);
        });

        return host;
    } 
}