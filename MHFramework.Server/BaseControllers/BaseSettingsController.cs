namespace MHFramework.Server;
public class BaseSettingsController<TEntity, TViewModel> : BaseController<TEntity, TViewModel>
    where TEntity : BaseSettingsEntity
    where TViewModel : BaseSettingsViewModel
{
    private readonly IBaseSettingsUnitOfWork<TEntity, TViewModel> _baseSettingsUnitOfWork;
    private readonly IValidator<TViewModel> _validator;

    protected BaseSettingsController(IBaseSettingsUnitOfWork<TEntity, TViewModel> unitOfWork, IValidator<TViewModel> validator) : base(unitOfWork, validator)
    {
        _baseSettingsUnitOfWork = unitOfWork;
        _validator = validator; 
    }

    [HttpGet("Search/{searchText}")]
    public virtual async Task<IEnumerable<TEntity>> Search([FromRoute] string searchText) => await _baseSettingsUnitOfWork.Search(searchText);
}