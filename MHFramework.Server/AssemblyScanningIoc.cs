using Serilog;

namespace MHFramework.Server;


public class AssemblyScanningIoc
{

    public List<Assembly>? RefrencedAssemblies { get; set; }

    //public static List<Assembly> GetReferencedAssemblies(Assembly assembly, string searchPattern)
    //{
    //    string? directoryName = new FileInfo(assembly.Location).DirectoryName;
    //    return Directory.GetFiles(directoryName,
    //            searchPattern).Select(Assembly.LoadFrom).ToList();
    //}

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



    //private static void a(IServiceCollection serviceCollection, string searchPattern, Type interfaceType)
    //{
    //    foreach (Type type in GetEntryAssemblyTypesImplemtsInterface(interfaceType, searchPattern))
    //    {
    //        try
    //        {
    //            if (Activator.CreateInstance(type) is IAPIBuilder instance)
    //                instance.Configure(serviceCollection);
    //        }
    //        catch (Exception ex)
    //        {
    //            Log.Error(ex, "knhkhk");
    //        }
    //    }
    //}


    //public static List<Type> GetEntryAssemblyTypesImplemtsInterface(
    //    Type interfaceType,
    //    string refrenceDllSearchPattern)
    //{
    //    InnoTypes.c c = new InnoTypes.c();
    //    c.a = interfaceType;
    //    Assembly entryAssembly = Assembly.GetEntryAssembly();
    //    c.b = entryAssembly.GetExportedTypes().Where(new Func<Type, bool>(c.a)).ToHashSet();
    //    GetReferencedAssemblies(entryAssembly, refrenceDllSearchPattern)
    //        .SelectMany(a => a.GetExportedTypes()).Where(new Func<Type, bool>(c.b)).ToList().ForEach(c.c);
    //    return c.b.ToList<Type>();
    //}

    public static List<Assembly> GetReferencedAssemblies(Assembly assembly, string searchPattern)
    {
        return Directory.GetFiles(new FileInfo(assembly.Location).DirectoryName!, searchPattern)
            .Select(Assembly.LoadFrom).ToList();
    }



    //public static MapperConfiguration ConfigureMapper<TEntity, TViewModel>()
    //where TEntity : BaseGetEntity
    //where TViewModel : BaseGetViewModel
    //{
    //    try
    //    {
    //        return new MapperConfiguration((Action<IMapperConfigurationExpression>)(a =>
    //        {
    //            a.AllowNullCollections = new bool?(true);
    //            a.CreateMap<TEntity, TViewModel>(MemberList.Source).ReverseMap();
    //            foreach (Type genericSubType in InnoTypes.GetGenericSubTypes(typeof(TViewModel), typeof(BaseGetViewModel), new HashSet<Type>()))
    //            {
    //                // ISSUE: object of a compiler-generated type is created
    //                // ISSUE: variable of a compiler-generated type
    //                InnoTypes.g<TEntity, TViewModel> g = new InnoTypes.g<TEntity, TViewModel>();
    //                // ISSUE: reference to a compiler-generated field
    //                g.a = genericSubType;
    //                try
    //                {
    //                    Dictionary<string, Type> allEntitiesTypes = InnoTypes.AllEntitiesTypes;
    //                    // ISSUE: reference to a compiler-generated method
    //                    Type sourceType = allEntitiesTypes != null ? allEntitiesTypes.FirstOrDefault<KeyValuePair<string, Type>>(new Func<KeyValuePair<string, Type>, bool>(g.a)).Value : (Type)null;
    //                    if (!(sourceType == (Type)null))
    //                    {
    //                        // ISSUE: reference to a compiler-generated field
    //                        a.CreateMap(sourceType, g.a, MemberList.Source).ReverseMap();
    //                    }
    //                }
    //                catch (Exception ex)
    //                {
    //                    string exceptionErrorString = Utilities.GetExceptionErrorString(ex);
    //                    Log.Error(ex, exceptionErrorString);
    //                }
    //            }
    //        }));
    //    }
    //    catch (Exception ex)
    //    {
    //        string exceptionErrorString = Utilities.GetExceptionErrorString(ex);
    //        Log.Error(ex, exceptionErrorString);
    //        return new MapperConfiguration((Action<IMapperConfigurationExpression>)(a => a.CreateMap<TEntity, TViewModel>(MemberList.Source).ReverseMap()));
    //    }
    //}
}