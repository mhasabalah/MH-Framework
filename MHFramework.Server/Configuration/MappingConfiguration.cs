namespace MHFramework.Server;
public class MappingConfiguration
{
    //public static MapperConfiguration ConfigureMapper<TEntity, TViewModel>()
    //where TEntity : BaseEntity
    //where TViewModel : BaseViewModel
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