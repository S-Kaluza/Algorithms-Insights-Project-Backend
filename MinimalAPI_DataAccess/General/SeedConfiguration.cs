using Microsoft.EntityFrameworkCore;
using MinimalAPI_Application.General;
using MinimalAPI_DataAccess.General.User;

namespace MinimalAPI_DataAccess.General;

public static class SeedConfiguration
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Status>().HasData(StatusSeed.Seed());
        modelBuilder.Entity<Roles>().HasData(RolesSeed.Seed());
    }
}