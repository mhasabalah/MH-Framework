namespace MHFramework.Server;

public class AssemblyScanning
{
    public static List<Assembly> GetReferencedAssemblies(Assembly assembly, string searchPattern)
    {
        string? directoryName = new FileInfo(assembly.Location).DirectoryName;
        return Directory.GetFiles(directoryName,
                searchPattern).Select(Assembly.LoadFrom).ToList();
    }

    private IEnumerable<Type> GetAllTypesThatImplementInterface<T>()
    {
        return Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(type => typeof(T).IsAssignableFrom(type) && !type.IsInterface);
    }

    //    private static void a(IServiceCollection serviceCollection, string dllFile, Type type)
    //    {
    //        foreach (Type type in GetEntryAssemblyTypesImplemtsInterface(type, dllFile))
    //        {
    //            try
    //            {
    //                if (Activator.CreateInstance(type) is IServerBuilder instance)
    //                    instance.Configure(a);
    //            }
    //            catch (Exception ex)
    //            {
    //                string exceptionErrorString = Utilities.GetExceptionErrorString(ex);
    //                Log.Error(ex, exceptionErrorString);
    //            }
    //        }
    //    }
}