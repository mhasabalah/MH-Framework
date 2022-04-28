namespace MHFramework.Shared;
public static class FluentValidationExtensions
{
    public static IRuleBuilderOptions<TViewModel, TProperty> NotEmpty<TViewModel, TProperty, Resource>(
      this IRuleBuilder<TViewModel, TProperty> ruleBuilder,
      IBaseLocalizer<TViewModel, Resource> localizer)
      where TViewModel : BaseViewModel
      where Resource : class
    {
        string? propertyName = ruleBuilder.GetPropertyName();
        string? loczlizedPropertyName = GetLoczlizedPropertyName(localizer, propertyName);
        IRuleBuilderOptions<TViewModel, TProperty> iruleBuilderOptions = DefaultValidatorExtensions.NotEmpty(ruleBuilder);
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
        interpolatedStringHandler.AppendFormatted(loczlizedPropertyName);
        interpolatedStringHandler.AppendLiteral(" ");
        interpolatedStringHandler.AppendFormatted<LocalizedString>(localizer.ValidationLocalizer["IsRequired"]);
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        return DefaultValidatorOptions.WithMessage(iruleBuilderOptions, stringAndClear);
    }

    public static IRuleBuilderOptions<TViewModel, string> MaximumLength<TViewModel, Resource>(
      this IRuleBuilder<TViewModel, string> ruleBuilder,
      int maximumLength,
      IBaseLocalizer<TViewModel, Resource> localizer)
      where TViewModel : BaseViewModel
      where Resource : class
    {
        string? propertyName = ruleBuilder.GetPropertyName();
        string? loczlizedPropertyName = GetLoczlizedPropertyName(localizer, propertyName);
        return DefaultValidatorOptions.WithMessage<TViewModel, string>(DefaultValidatorExtensions.MaximumLength(ruleBuilder, maximumLength), loczlizedPropertyName + " " + string.Format(localizer.ValidationLocalizer[nameof(MaximumLength)].Value, (object)maximumLength));
    }

    public static IRuleBuilderOptions<TViewModel, TProperty> GreaterThan<TViewModel, TProperty, Resource>(
      this IRuleBuilder<TViewModel, TProperty> ruleBuilder,
      Expression<Func<TViewModel, TProperty>> expression,
      IBaseLocalizer<TViewModel, Resource> localizer)
      where TViewModel : BaseViewModel
      where TProperty : IComparable<TProperty>, IComparable
      where Resource : class
    {
        string? propertyName = ruleBuilder.GetPropertyName();
        string? name = (((MemberExpression) expression.Body).Member as PropertyInfo)?.Name;
        string? loczlizedPropertyName1 = GetLoczlizedPropertyName(localizer, propertyName);
        string? loczlizedPropertyName2 = GetLoczlizedPropertyName(localizer, name);
        return DefaultValidatorOptions.WithMessage(DefaultValidatorExtensions.GreaterThan(ruleBuilder, expression), loczlizedPropertyName1 + " " + string.Format(localizer.ValidationLocalizer[nameof(GreaterThan)].Value, loczlizedPropertyName2));
    }

    public static IRuleBuilderOptions<TViewModel, TProperty> GreaterThanOrEqualTo<TViewModel, TProperty, Resource>(
      this IRuleBuilder<TViewModel, TProperty> ruleBuilder,
      Expression<Func<TViewModel, TProperty>> expression,
      IBaseLocalizer<TViewModel, Resource> localizer)
      where TViewModel : BaseViewModel
      where TProperty : IComparable<TProperty>, IComparable
      where Resource : class
    {
        string? propertyName = ruleBuilder.GetPropertyName();
        string? name = (((MemberExpression) expression.Body).Member as PropertyInfo)?.Name;
        string? loczlizedPropertyName1 = GetLoczlizedPropertyName(localizer, propertyName);
        string? loczlizedPropertyName2 = GetLoczlizedPropertyName(localizer, name);
        return DefaultValidatorExtensions.GreaterThanOrEqualTo(ruleBuilder, expression).WithMessage(loczlizedPropertyName1 + " " + string.Format(localizer.ValidationLocalizer[nameof(GreaterThanOrEqualTo)].Value, loczlizedPropertyName2));
    }

    public static IRuleBuilderOptions<TViewModel, TProperty> LessThan<TViewModel, TProperty, Resource>(
      this IRuleBuilder<TViewModel, TProperty> ruleBuilder,
      Expression<Func<TViewModel, TProperty>> expression,
      IBaseLocalizer<TViewModel, Resource> localizer)
      where TViewModel : BaseViewModel
      where TProperty : IComparable<TProperty>, IComparable
      where Resource : class
    {
        string? propertyName = ruleBuilder.GetPropertyName();
        string? name = (((MemberExpression) expression.Body).Member as PropertyInfo)?.Name;
        string? loczlizedPropertyName1 = GetLoczlizedPropertyName(localizer, propertyName);
        string? loczlizedPropertyName2 = GetLoczlizedPropertyName(localizer, name);
        return DefaultValidatorOptions.WithMessage(DefaultValidatorExtensions.LessThan(ruleBuilder, expression), loczlizedPropertyName1 + " " + string.Format(localizer.ValidationLocalizer[nameof(LessThan)].Value, loczlizedPropertyName2));
    }

    public static IRuleBuilderOptions<TViewModel, TProperty> LessThanOrEqualTo<TViewModel, TProperty, Resource>(
      this IRuleBuilder<TViewModel, TProperty> ruleBuilder,
      Expression<Func<TViewModel, TProperty>> expression,
      IBaseLocalizer<TViewModel, Resource> localizer)
      where TViewModel : BaseViewModel
      where TProperty : IComparable<TProperty>, IComparable
      where Resource : class
    {
        string? propertyName = ruleBuilder.GetPropertyName<TViewModel, TProperty>();
        string? name = ((expression.Body as MemberExpression).Member as PropertyInfo).Name;
        string? loczlizedPropertyName1 = GetLoczlizedPropertyName(localizer, propertyName);
        string? loczlizedPropertyName2 = GetLoczlizedPropertyName(localizer, name);
        return DefaultValidatorExtensions.LessThanOrEqualTo(ruleBuilder, expression).WithMessage(loczlizedPropertyName1 + " " + string.Format(localizer.ValidationLocalizer[nameof(LessThanOrEqualTo)].Value, loczlizedPropertyName2));
    }

    private static string? GetLoczlizedPropertyName<TViewModel, Resource>(
      IBaseLocalizer<TViewModel, Resource> localizer,
      string? propertyName)
      where TViewModel : BaseViewModel
      where Resource : class
    {
        propertyName = !localizer.SharedLocalizer.GetAllStrings(true).Any(v => v.Name.Equals(propertyName)) ? (string)localizer.EntityLocalizer[propertyName] : localizer.SharedLocalizer[propertyName];
        return propertyName;
    }

    public static IRuleBuilderOptions<TViewModel, string> Length<TViewModel, Resource>(
      this IRuleBuilder<TViewModel, string> ruleBuilder,
      int min,
      int max,
      IBaseLocalizer<TViewModel, Resource> localizer)
      where TViewModel : BaseViewModel
      where Resource : class
    {
        string? propertyName = ruleBuilder.GetPropertyName();
        string? loczlizedPropertyName = GetLoczlizedPropertyName(localizer, propertyName);
        return DefaultValidatorOptions.WithMessage<TViewModel, string>(DefaultValidatorExtensions.Length(ruleBuilder, min, max), loczlizedPropertyName + " " + string.Format(localizer.ValidationLocalizer[nameof(Length)].Value, min, max));
    }

    public static IRuleBuilderOptions<TViewModel, TProperty> NotNull<TViewModel, TProperty, Resource>(
      this IRuleBuilder<TViewModel, TProperty> ruleBuilder,
      IBaseLocalizer<TViewModel, Resource> localizer)
      where TViewModel : BaseViewModel
      where Resource : class
    {
        string? propertyName = ruleBuilder.GetPropertyName();
        string? loczlizedPropertyName = GetLoczlizedPropertyName(localizer, propertyName);
        IRuleBuilderOptions<TViewModel, TProperty> iruleBuilderOptions = DefaultValidatorExtensions.NotNull(ruleBuilder);
        DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
        interpolatedStringHandler.AppendFormatted(loczlizedPropertyName);
        interpolatedStringHandler.AppendLiteral(" ");
        interpolatedStringHandler.AppendFormatted(localizer.ValidationLocalizer["IsRequired"]);
        string stringAndClear = interpolatedStringHandler.ToStringAndClear();
        return DefaultValidatorOptions.WithMessage(iruleBuilderOptions, stringAndClear);
    }

    public static string? GetPropertyName<TViewModel, TProperty>(
      this IRuleBuilder<TViewModel, TProperty> ruleBuilder)
      where TViewModel : BaseViewModel
    {
        string? propertyName = null;
        DefaultValidatorOptions.WithMessage(DefaultValidatorExtensions.NotEmpty(ruleBuilder)
            ?.Configure(config => propertyName = config.PropertyName), " ");
        return propertyName;
    }
}