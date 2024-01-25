using Microsoft.Extensions.DependencyInjection;
using Salvation.Library.Infrastructure.Abstractions;
using Salvation.Library.Infrastructure.Implementations;
using Salvation.Library.Services;
using Salvation.Services.AuthHandler.Abstractions;
using Salvation.Services.AuthHandler.Implementations;

namespace Salvation.Services.AuthHandler;

/// <summary>
/// HandlerRegister
/// </summary>
public static class HandlerRegister
{
    /// <summary>
    /// RegisterHandler
    /// </summary>
    /// <param name="services"></param>
    public static void RegisterHandler(this IServiceCollection services)
    {
        services.AddTransient<IAccountHandler, AccountHandler>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.RegisterServiceProviders();
    }
}
