namespace MHFramework.Shared; 
public class BaseValidator<TViewModel, Resource> :
    AbstractValidator<TViewModel>,
    IValidator<TViewModel>,
    IValidator
    where TViewModel : BaseViewModel
    where Resource : class
{
    public BaseValidator(IBaseLocalizer<TViewModel, Resource> localizer)
    {
    }
}