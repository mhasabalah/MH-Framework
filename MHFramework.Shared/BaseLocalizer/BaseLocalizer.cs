namespace MHFramework.Shared;
public class BaseLocalizer<TViewModel, Resource> : IBaseLocalizer<TViewModel, Resource>
    where TViewModel : BaseViewModel
    where Resource : class
{
    public BaseLocalizer(
        IStringLocalizer<Resource> entityLocalizer,
        IStringLocalizer<SharedResource> sharedLocalizer,
        IStringLocalizer<ValidationResource> validationLocalizer,
        IStringLocalizer<ExceptionResource> exceptionLocalizer)
    {
        EntityLocalizer = entityLocalizer;
        SharedLocalizer = sharedLocalizer;
        ValidationLocalizer = validationLocalizer;
        ExceptionLocalizer = exceptionLocalizer;
    }

    public IStringLocalizer<Resource> EntityLocalizer { get; }
    public IStringLocalizer<SharedResource> SharedLocalizer { get; }
    public IStringLocalizer<ValidationResource> ValidationLocalizer { get; }
    public IStringLocalizer<ExceptionResource> ExceptionLocalizer { get; }
}