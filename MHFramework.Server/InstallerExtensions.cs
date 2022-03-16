namespace MHFramework.Server;

public static class InstallerExtensions
{
    public static void AddInstallersFromAssemblyContaining<TMaker>(
        this IServiceCollection services, IConfiguration configuration)
    {
        AddInstallersFromAssembliesContaining(services, configuration, typeof(TMaker));
    }

    public static void AddInstallersFromAssembliesContaining(
        this IServiceCollection services, IConfiguration configuration, params Type[] assemblyMarkers)
    {
        var assemblies = assemblyMarkers.Select(x => x.Assembly).ToArray();
        AddInstallersFromAssemblies(services, configuration, assemblies);
    }

    public static void AddInstallersFromAssemblies(
        this IServiceCollection services, IConfiguration configuration, params Assembly[] assemblies)
    {
        foreach (var assembly in assemblies)
        {
            var installerTypes = assembly.DefinedTypes.Where(x =>
                typeof(IServerBuilder).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

            var installers = installerTypes.Select(Activator.CreateInstance).Cast<IServerBuilder>();
            foreach (var installer in installers.OrderBy(x => x.Order))
            {
                installer.AddServices(services, configuration);
            }
        }
    }
}