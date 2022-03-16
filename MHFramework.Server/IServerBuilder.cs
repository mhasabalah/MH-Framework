namespace MHFramework.Server;

public interface IServerBuilder
{
    void AddServices(IServiceCollection services, IConfiguration configuration);

    public int Order => -1;
}