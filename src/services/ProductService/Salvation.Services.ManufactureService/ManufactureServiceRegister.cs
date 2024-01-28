using Microsoft.Extensions.DependencyInjection;
using Salvation.Library.Common;
using Salvation.Library.Infrastructure.Abstractions;
using Salvation.Library.Infrastructure.Implementations;
using Salvation.Library.Services.Manufactures.Abstractions;
using Salvation.Library.Services.Manufactures.Implementations;

namespace Salvation.Services.Manufactures;

/// <summary>
/// ServiceProviderRegister
/// </summary>
public static class ManufactureServiceRegister
{
    /// <summary>
    /// RegisterManufactureService
    /// </summary>
    /// <param name="services"></param>
    public static void RegisterManufactureService(this IServiceCollection services)
    {
        services.AddTransient<IManufactureService, ManufactureService>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.RegisterProviders();
    }
}
