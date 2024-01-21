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
        services.AddTransient<IConfigProvider, ConfigProvider>();
        services.AddTransient<ICookieProvider, CookieProvider>();
        services.AddTransient<IHashProvider, HashProvider>();
        services.AddTransient<IStringProvider, StringProvider>();
        services.AddTransient<IMemCacheProvider, MemCacheProvider>();
    }
}
