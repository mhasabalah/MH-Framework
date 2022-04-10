namespace MHFramework.Client;
public class CommonClientInstaller :IInstaller
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions();
        services.AddAuthorizationCore();
        services.AddScoped<IdentityAuthenticationStateProvider>();
        services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<IdentityAuthenticationStateProvider>());
        services.AddScoped<IAuthorizeApi, AuthorizeApi>();
    }
}