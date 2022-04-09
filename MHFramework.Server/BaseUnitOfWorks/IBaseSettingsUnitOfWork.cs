namespace MHFramework.Server;

public interface IBaseSettingsUnitOfWork<TEntity, TViewModel> : IBaseUnitOfWork<TEntity, TViewModel>, IDisposable
    where TEntity : BaseSettingsEntity
    where TViewModel : BaseViewModel
{
    Task<IEnumerable<TEntity>> Search(string searchText);
}