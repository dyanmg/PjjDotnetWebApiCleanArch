using Microsoft.Extensions.DependencyInjection;
using PjjDotnetWebApiCleanArch.Application.Interfaces.Service;
using PjjDotnetWebApiCleanArch.Application.Services;

namespace PjjDotnetWebApiCleanArch.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);
        services.AddScoped<KategoriService>();
        services.AddScoped<IAsetService, AsetService>();
        services.AddScoped<PegawaiService>();
        return services;
    } 
}