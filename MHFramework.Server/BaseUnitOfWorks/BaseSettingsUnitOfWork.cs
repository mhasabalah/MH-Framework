namespace MHFramework.Server;
public class BaseSettingsUnitOfWork<TEntity, TViewModel> :
    BaseUnitOfWork<TEntity, TViewModel>, IBaseSettingsUnitOfWork<TEntity, TViewModel>
    where TEntity : BaseSettingsEntity
    where TViewModel : BaseViewModel
{
    private readonly IBaseSettingsRepository<TEntity> _baseSettingsRepository;
    public BaseSettingsUnitOfWork(IBaseSettingsRepository<TEntity> repository, IMapper mapper)
        : base(repository, mapper) => _baseSettingsRepository = repository;

    public async Task<IEnumerable<TEntity>> Search(string searchText) => await _baseSettingsRepository.Search(searchText);
}