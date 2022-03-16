namespace MHFramework.shared;

public interface IBaseLocalizer<TEntity, Resource>
    where TEntity : BaseEntity
    where Resource : class
{
    IStringLocalizer<Resource> EntityLocalizer { get; }
}