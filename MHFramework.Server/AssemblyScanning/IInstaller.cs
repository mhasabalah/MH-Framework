namespace MHFramework.Server;

public interface IInstaller
{
    void ConfigureServices(IServiceCollection services, IConfiguration configuration);
}