namespace MHFramework.Shared;
public interface IInstaller
{
    void ConfigureServices(IServiceCollection services, IConfiguration configuration);
}