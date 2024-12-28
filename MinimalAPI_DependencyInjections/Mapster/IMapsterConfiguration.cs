namespace MinimalAPI_DependencyInjections.Mapster;

public interface IMapsterConfiguration
{
    MapsterConfiguration Scan();
    MapsterConfiguration Compile();
}