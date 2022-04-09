namespace MHFramework.Server;
public interface IBaseUnitOfWork<TEntity, TViewModel> : IDisposable
    where TEntity : BaseEntity
    where TViewModel : BaseViewModel
{
    Task<TViewModel> Create(TViewModel viewModel);
    Task<IEnumerable<TViewModel>> Create(IEnumerable<TViewModel> viewModels);

    Task<IEnumerable<TViewModel>> Read();
    Task<TViewModel> Read(Guid id);

    Task<TViewModel> Update(TViewModel viewModel);
    Task<IEnumerable<TViewModel>> Update(IEnumerable<TViewModel> viewModels);

    Task<TViewModel> Delete(Guid id);
    Task<TViewModel> Delete(TViewModel entity);
    Task<IEnumerable<TViewModel>> Delete(IEnumerable<TViewModel> viewModels);

}