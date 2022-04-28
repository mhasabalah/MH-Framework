namespace MHFramework.Shared;
public class BaseSettingsValidator<TViewModel, Resource> : BaseValidator<TViewModel, Resource>
    where TViewModel : BaseSettingsViewModel
    where Resource : class
{
    public BaseSettingsValidator(IBaseLocalizer<TViewModel, Resource> localizer) : base(localizer)
    {

        RuleFor(e=>e.Name).NotEmpty(localizer)!.MaximumLength(500, localizer);
    }
}