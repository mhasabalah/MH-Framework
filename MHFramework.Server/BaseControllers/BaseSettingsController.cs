namespace MHFramework.Server;
public class BaseSettingsController<TEntity, TViewModel> : BaseController<TEntity, TViewModel>
    where TEntity : BaseSettingsEntity
    where TViewModel : BaseSettingsViewModel
{
    private readonly IBaseSettingsUnitOfWork<TEntity, TViewModel> _baseSettingsUnitOfWork;

    protected BaseSettingsController(IBaseSettingsUnitOfWork<TEntity, TViewModel> unitOfWork) : base(unitOfWork) => _baseSettingsUnitOfWork = unitOfWork;

    [HttpGet("Search/{searchText}")]
    public virtual async Task<IEnumerable<TEntity>> Search([FromRoute] string searchText) => await _baseSettingsUnitOfWork.Search(searchText);
}