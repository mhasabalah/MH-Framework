namespace MHFramework.Server;
public abstract class BaseController<TEntity, TViewModel> : ControllerBase
    where TEntity : BaseEntity
    where TViewModel : BaseViewModel
{
    private readonly IValidator<TViewModel> _validator;
    private readonly IBaseUnitOfWork<TEntity, TViewModel> _unitOfWork;
    public BaseController(IBaseUnitOfWork<TEntity, TViewModel> unitOfWork, IValidator<TViewModel> validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator; ;
    }

    [HttpGet]
    public virtual async Task<IActionResult> Get()
    {
        IEnumerable<TViewModel> viewModels = await _unitOfWork.Read();
        return Ok(viewModels);
    }

    [HttpGet("id")]
    public virtual async Task<IActionResult> Get(Guid id)
    {
        TViewModel viewModel = await _unitOfWork.Read(id);
        return Ok(viewModel);
    }

    [HttpPost]
    public virtual async Task<IActionResult> Post(TViewModel viewModel)
    {
        if (viewModel == null)
            return BadRequest("ViewModel can not be null");

        var result = _validator.Validate(viewModel);
        if (!result.IsValid)
        {
            string text = string.Join("-", result.Errors.Select(e => e.ErrorMessage));
            throw new Exception("NonValid ViewModel Reason:" + text);
        }

        viewModel = await _unitOfWork.Create(viewModel);
        
        return Ok(viewModel);
    }

    [HttpPut]
    public virtual async Task<IActionResult> Put(TViewModel viewModel)
    {

        if (viewModel == null)
            return BadRequest("ViewModel can not be null");

        var result = _validator.Validate(viewModel);
        if (!result.IsValid)
        {
            string text = string.Join("-", result.Errors.Select(e => e.ErrorMessage));
            throw new Exception("NonValid ViewModel Reason:" + text);
        }

        viewModel = await _unitOfWork.Update(viewModel);

        return Ok(viewModel);
    }

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> Delete(Guid id)
    {
        TViewModel viewModel = await _unitOfWork.Delete(id);
        return Ok(viewModel);
    }

    //[HttpPost]
    //public virtual async Task Post(TEntity entity) => await _unitOfWork.Create(entity);
    //[HttpGet]
    //public virtual async Task<IEnumerable<TEntity>> Get() => await _unitOfWork.Read();
    //[HttpGet("{id}")]
    //public virtual async Task<TEntity> Get([FromRoute] Guid id) => await _unitOfWork.Read(id);

    //[HttpPut]
    //public virtual async Task Put(TEntity entity) => await _unitOfWork.Update(entity);

    //[HttpDelete("{id}")]
    //public virtual async Task Delete(Guid id) => await _unitOfWork.Delete(id);
}