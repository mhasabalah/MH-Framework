namespace MHFramework.Server;
public abstract class BaseSettingsRepository<TEntity> : BaseRepository<TEntity>, IBaseSettingsRepository<TEntity>
    where TEntity : BaseSettingsEntity
{
    public BaseSettingsRepository(GenericContext context) : base(context) { }

    public async Task<IEnumerable<TEntity>> Search(string searchText) => await
        Task.Run(() => dbSet.Where(e => e.Name.Contains(searchText)));

}

