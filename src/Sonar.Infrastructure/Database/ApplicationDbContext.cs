using Microsoft.EntityFrameworkCore;

namespace Sonar.Infrastructure.Database;

public sealed class ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options
        ) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.HasDefaultSchema(Schemas.Default);
    }
}
