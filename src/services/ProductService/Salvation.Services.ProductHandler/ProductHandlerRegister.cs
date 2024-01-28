using Microsoft.Extensions.DependencyInjection;
using Salvation.Handlers.Products.Abstractions;
using Salvation.Handlers.Products.Implementations;
using Salvation.Library.Infrastructure.Abstractions;
using Salvation.Library.Infrastructure.Implementations;
using Salvation.Library.Common;
using Salvation.Services.Categories;
using Salvation.Services.Manufactures;
using Salvation.Services.Products;

namespace Salvation.Handlers.Products;

/// <summary>
/// HandlerRegister
/// </summary>
public static class ProductHandlerRegister
{
    /// <summary>
    /// RegisterHandler
    /// </summary>
    /// <param name="services"></param>
    public static void RegisterProductHandler(this IServiceCollection services)
    {
        services.AddTransient<IProductHandler, ProductHandler>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.RegisterProviders();
        services.RegisterCategoryService();
        services.RegisterManufactureService();
        services.RegisterProductService();
    }
}
