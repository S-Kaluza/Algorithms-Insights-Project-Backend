using Microsoft.EntityFrameworkCore;
using MinimalAPI_DataAccess;
using MinimalAPI_Domain.Users.Queries.GetUserById.Request;
using MinimalAPIWebApplication.EndpointDefinition;
using Npgsql;

namespace MinimalAPIWebApplication;

public static class MinimalApiExtension
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        var cs = builder.Configuration.GetConnectionString("Default");
        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(cs));
        builder.Services.AddTransient<NpgsqlConnection>(_ =>
            new NpgsqlConnection()
        );
        builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblyContaining<GetUserById>(); });
    }

    public static void RegisterEndpointDefinitions(this WebApplication app)
    {
        var endpointDefinitions = typeof(Program).Assembly.GetTypes()
            .Where(t => t.IsAssignableTo(typeof(IEndpointDefinition)) && !t.IsAbstract && !t.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IEndpointDefinition>();
        foreach (var endpointDefinition in endpointDefinitions) endpointDefinition.RegisterEndpoints(app);
    }
}