using PjjDotnetWebApiCleanArch.Api;
using PjjDotnetWebApiCleanArch.Api.Extensions;
using PjjDotnetWebApiCleanArch.Api.Middlewares;
using PjjDotnetWebApiCleanArch.Application;
using PjjDotnetWebApiCleanArch.Domain.Entities;
using PjjDotnetWebApiCleanArch.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AddPresentationLogging();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddPresentation(builder.Configuration, builder.Environment);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.AddDevAppDependency();
}

app.MapGet("/health", () => Results.Ok("Healthy"));

app.UseAuthorization();
app.UseMiddleware<SampleMiddleware>();
app.UseExceptionHandler("/error");

app.MapControllers();

app.MapGroup("/api/Account")
    .MapIdentityApi<Pegawai>()
    .WithTags("Account");

app.UseCors("AllowAll");

app.Run();
