namespace MHFramework.Shared;
public interface IBaseLocalizer<TViewModel, Resource>
    where TViewModel : BaseViewModel
    where Resource : class
{
    IStringLocalizer<Resource> EntityLocalizer { get; }
    IStringLocalizer<SharedResource> SharedLocalizer { get; }
    //IStringLocalizer<ValidationResource> ValidationLocalizer { get; }
    //IStringLocalizer<ExceptionResource> ExceptionLocalizer { get; }
}