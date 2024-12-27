using FastExpressionCompiler;
using Mapster;

namespace MinimalAPI_DependencyInjections.Mapster;

public class MapsterConfiguration : IMapsterConfiguration
{
    public MapsterConfiguration()
    {
        TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileFast();
        TypeAdapterConfig.GlobalSettings.AllowImplicitDestinationInheritance = true;
    }

    public MapsterConfiguration Scan()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        if (assemblies != null && assemblies.Length > 0)
        {
            var baseType = typeof(IRegister);
            foreach (var assembly in assemblies)
                if (assembly.ManifestModule.Name.Contains("TeacherApi"))
                {
                    var registers = assembly.GetTypes()
                        .Where(x => x != null && !x.IsAbstract && !x.IsInterface && baseType.IsAssignableFrom(x))
                        .ToList();
                    foreach (var mpType in registers)
                        (Activator.CreateInstance(mpType) as IRegister)!.Register(TypeAdapterConfig.GlobalSettings);
                }
        }

        return this;
    }

    public MapsterConfiguration Compile()
    {
        TypeAdapterConfig.GlobalSettings.Compile();
        return this;
    }
}