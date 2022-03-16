namespace MHFramework.shared;
public class BaseSettingValidator<TEntity, Resource> : BaseValidator<TEntity, Resource>
    where TEntity : BaseSettingsEntity
    where Resource : class

{
    public BaseSettingValidator(IBaseLocalizer<TEntity, Resource> localizer) : base(localizer)
    {
        const int nameMaxLength = 20;


        RuleFor(e => e.Name).NotEmpty().WithMessage($"{nameof(TEntity)} Name is not empty");
        RuleFor(e => e.Name).MaximumLength(nameMaxLength).WithMessage($"{nameof(TEntity)} Name max length = {nameMaxLength}");
    }
}