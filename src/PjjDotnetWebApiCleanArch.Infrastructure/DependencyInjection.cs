using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PjjDotnetWebApiCleanArch.Application.Interfaces;
using PjjDotnetWebApiCleanArch.Application.Interfaces.Repository;
using PjjDotnetWebApiCleanArch.Application.Interfaces.Service.ExternalClient;
using PjjDotnetWebApiCleanArch.Domain.Entities;
using PjjDotnetWebApiCleanArch.Infrastructure.Identity.ClaimsPrincipalFactory;
using PjjDotnetWebApiCleanArch.Infrastructure.Integrations.TypiCode;
using PjjDotnetWebApiCleanArch.Infrastructure.Persistence;
using PjjDotnetWebApiCleanArch.Infrastructure.Repositories;

namespace PjjDotnetWebApiCleanArch.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSqlite<AppDbContext>(configuration.GetConnectionString("DefaultConnection"));
        
        services.AddIdentityCore<Pegawai>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddClaimsPrincipalFactory<PegawaiClaimsPrincipalFactory>();

        services.AddScoped<IRepository<Pegawai>, Repository<Pegawai>>();
        services.AddScoped<IRepository<Aset>, Repository<Aset>>();
        services.AddScoped<IRepository<Kategori>, Repository<Kategori>>();
        services.AddScoped<IPegawaiRepository, PegawaiRepository>();
        services.AddScoped<IAsetRepository, AsetRepository>();
        services.AddScoped<IUnitOfWorks, UnitOfWorks>();
        
        services.AddHttpClient<ITypiCodeClient, TypiCodeClient>();

        return services;
    } 
}