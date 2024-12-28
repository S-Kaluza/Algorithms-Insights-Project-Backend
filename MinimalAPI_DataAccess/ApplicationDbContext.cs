using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinimalAPI_Application.General;
using MinimalAPI_Application.Models.Entity.User;
using MinimalAPI_DataAccess.General;

namespace MinimalAPI_DataAccess;

public class ApplicationDbContext : IdentityDbContext<User, Roles, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Roles> Roles { get; set; }
    public DbSet<Status> Status { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        base.OnModelCreating(builder);
        builder.HasPostgresExtension("uuid-ossp");
        builder.HasPostgresExtension("pg_trgm");
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        SeedConfiguration.Seed(builder);
    }
}