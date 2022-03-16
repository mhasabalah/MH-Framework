namespace MHFramework.Shared;

public abstract class BaseViewModel<TEntity> where TEntity : class
{
    public TEntity? Entity { get; set; }
}