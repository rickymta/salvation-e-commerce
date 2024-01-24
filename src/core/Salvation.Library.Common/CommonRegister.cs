using Salvation.Library.Common.Abstractions;
using Salvation.Library.Common.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Salvation.Library.Common;

/// <summary>
/// ProviderRegister
/// </summary>
public static class CommonRegister
{
    /// <summary>
    /// AddProviderServices
    /// </summary>
    /// <param name="services"></param>
    public static void RegisterProviders(this IServiceCollection services)
    {
        services.AddTransient<IAdminApiProvider, AdminApiProvider>();
        services.AddTransient<IConfigProvider, ConfigProvider>();
        services.AddTransient<ICookieProvider, CookieProvider>();
        services.AddTransient<ICoreApiProvider, CoreApiProvider>();
        services.AddTransient<ICustomerApiProvider, CustomerApiProvider>();
        services.AddTransient<IHashProvider, HashProvider>();
        services.AddTransient<IJwtProvider, JwtProvider>();
        services.AddTransient<ILogProvider, LogProvider>();
        services.AddTransient<IMemCacheProvider, MemCacheProvider>();
        services.AddTransient<IObjectProvider, ObjectProvider>();
        services.AddTransient<IRestProvider, RestProvider>();
        services.AddTransient<IStringProvider, StringProvider>();
    }
}
