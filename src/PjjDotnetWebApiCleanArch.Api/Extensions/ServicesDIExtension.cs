using System.Reflection;

namespace PjjDotnetWebApiCleanArch.Api.Extensions;

public static class ServicesDIExtension
{
    public static IServiceCollection RegisterSwagger(this IServiceCollection services)
    {
       return services.AddSwaggerGen(config =>
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            var xmlFile = $"{assemblyName}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            if (File.Exists(xmlPath))
            {
                config.IncludeXmlComments(xmlPath);
            }
        });
    }

    public static void AddDevAppDependency(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.MapOpenApi();
    }
}
