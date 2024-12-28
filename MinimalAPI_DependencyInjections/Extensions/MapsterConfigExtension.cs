using Microsoft.Extensions.DependencyInjection;
using MinimalAPI_DependencyInjections.Mapster;

namespace MinimalAPI_DependencyInjections.Extensions;

public static class MapsterConfigExtensions
{
    public static void AddMapster(this IServiceCollection services)
    {
        services.AddSingleton<IMapsterConfiguration, MapsterConfiguration>();
    }
}