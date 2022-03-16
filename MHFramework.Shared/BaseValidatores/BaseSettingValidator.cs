namespace MHFramework.Shared;
public class BaseSettingsValidator<TViewModel, Resource> : BaseValidator<TViewModel, Resource>
    where TViewModel : BaseSettingsViewModel
    where Resource : class
{
    public BaseSettingsValidator(IBaseLocalizer<TViewModel, Resource> localizer)
        : base(localizer)
    {
        const int nameMaxLength = 50;
        RuleFor(e => e.Name).NotEmpty().WithMessage($"{nameof(TViewModel)} Name is not empty");
        RuleFor(e => e.Name).MaximumLength(nameMaxLength).WithMessage($"{nameof(TViewModel)} Name max length = {nameMaxLength}");
    }
}