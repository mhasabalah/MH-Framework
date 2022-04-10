namespace MHFramework.Server;
public class BaseUnitOfWork<TEntity, TViewModel> : IBaseUnitOfWork<TEntity, TViewModel>
    where TEntity : BaseEntity
    where TViewModel : BaseViewModel

{
    private readonly IBaseRepository<TEntity> _repository;
    protected readonly IMapper _mapper;

    public BaseUnitOfWork(IBaseRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public virtual async Task<IEnumerable<TViewModel>> Read()
    {
        IEnumerable<TEntity> entities =  await _repository.Get();
        return _mapper.Map<IEnumerable<TViewModel>>(entities);
    }
    public virtual async Task<TViewModel> Read(Guid id)
    {
        TEntity entity = await _repository.Get(id);
        return _mapper.Map<TViewModel>(entity);
    }

    public virtual async Task<TViewModel> Update(TViewModel viewModel)
    {
        TEntity entity = _mapper.Map<TEntity>(viewModel);
        using IDbContextTransaction transaction = await _repository.GetTransaction();
        
        TEntity entityFromDb = await _repository.Update(entity);
        await transaction.CommitAsync();

        return _mapper.Map<TViewModel>(entityFromDb);
    }

    public virtual async Task<TViewModel> Create(TViewModel viewModel)
    {
        TEntity entity = _mapper.Map<TEntity>(viewModel);
        using IDbContextTransaction transaction = await _repository.GetTransaction();
        TEntity entityFromDb = await _repository.Add(entity);
        await transaction.CommitAsync();

        return _mapper.Map<TViewModel>(entityFromDb);
    }
    public virtual async Task<IEnumerable<TViewModel>> Create(IEnumerable<TViewModel> viewModels)
    {
        using IDbContextTransaction transaction = await _repository.GetTransaction();

        IEnumerable<TEntity> entities = viewModels.Select(e => _mapper.Map<TEntity>(e));
        await _repository.Add(entities);

        await transaction.CommitAsync();
        return entities.Select(e=> _mapper.Map<TViewModel>(e)) ;
    }
    public virtual async Task<IEnumerable<TViewModel>> Update(IEnumerable<TViewModel> viewModels)
    {
        IEnumerable<TEntity> entities = viewModels.Select(e => _mapper.Map<TEntity>(e));
        using IDbContextTransaction transaction = await _repository.GetTransaction();
        await _repository.Update(entities);

        await transaction.CommitAsync();
        return entities.Select(e => _mapper.Map<TViewModel>(e));
    }

    public virtual async Task<TViewModel> Delete(Guid id)
    {
        using IDbContextTransaction transaction = await _repository.GetTransaction();
        TEntity entityFromDb = await _repository.Remove(id);

        await transaction.CommitAsync();
        return _mapper.Map<TViewModel>(entityFromDb);
    }
    public virtual async Task<TViewModel> Delete(TViewModel viewModel)
    {
        TEntity entity = _mapper.Map<TEntity>(viewModel);
        using IDbContextTransaction transaction = await _repository.GetTransaction();
        TEntity entityFromDb = await _repository.Remove(entity);

        await transaction.CommitAsync();
        return _mapper.Map<TViewModel>(entityFromDb);
    }

    public async Task<IEnumerable<TViewModel>> Delete(IEnumerable<TViewModel> viewModels)
    {
        var entities = viewModels.Select(e => _mapper.Map<TEntity>(e));
        using IDbContextTransaction transaction = await _repository.GetTransaction();
        var entitiesFromDb= await _repository.Remove(entities);
        await transaction.CommitAsync();
        return entitiesFromDb.Select(e => _mapper.Map<TViewModel>(e));
    }

    public virtual async Task Delete(IEnumerable<TEntity> entities)
    {
        using IDbContextTransaction transaction = await _repository.GetTransaction();
        await _repository.Remove(entities);

        await transaction.CommitAsync();
    }

    public void Dispose() => _repository.Dispose();
}