namespace MHFramework.Server;

public static class RepositoryUtiliyies<TEntity>
{
    private static void ThrowExceptionIfParameterNotSupplied(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException($"{nameof(TEntity)} was not provided.");
    }
    private static void ThrowExceptionIfParameterNotSupplied(IEnumerable<TEntity> entities)
    {
        if (entities == null || !entities.Any())
            throw new ArgumentNullException($"{nameof(TEntity)} was not provided.");
    }
}

