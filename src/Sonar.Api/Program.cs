using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Sonar.Infrastructure;
using Sonar.Infrastructure.Database;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.AddServiceDefaults();
builder.Services.AddOpenApi();

// Configure application modules
{
    builder
        .Services
        .AddInfrastructure(builder.Configuration);

    builder.EnrichNpgsqlDbContext<ApplicationDbContext>();
}

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference("/api-docs");

    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();

app.Run();
