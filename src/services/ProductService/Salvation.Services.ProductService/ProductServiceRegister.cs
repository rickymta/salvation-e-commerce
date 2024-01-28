using Microsoft.Extensions.DependencyInjection;
using Salvation.Library.Common;
using Salvation.Library.Infrastructure.Abstractions;
using Salvation.Library.Infrastructure.Implementations;
using Salvation.Library.Services.Products.Abstractions;
using Salvation.Library.Services.Products.Implementations;

namespace Salvation.Services.Products;

/// <summary>
/// ServiceProviderRegister
/// </summary>
public static class ProductServiceRegister
{
    /// <summary>
    /// RegisterProductService
    /// </summary>
    /// <param name="services"></param>
    public static void RegisterProductService(this IServiceCollection services)
    {
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.RegisterProviders();
    }
}
