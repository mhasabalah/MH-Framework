namespace MHFramework.Server;
public class CommonServerInstaller : IInstaller
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IBaseSettingsRepository<>), typeof(BaseSettingsRepository<>));
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped(typeof(IBaseSettingsUnitOfWork<,>), typeof(BaseSettingsUnitOfWork<,>));
        services.AddScoped(typeof(IBaseUnitOfWork<,>), typeof(BaseUnitOfWork<,>));

        //services.AddFluentValidation(options =>
        //{
        //    options.AutomaticValidationEnabled = true;
        //    options.DisableDataAnnotationsValidation = true;
        //});
    }
}