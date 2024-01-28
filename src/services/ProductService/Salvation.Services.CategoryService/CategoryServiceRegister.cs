using Microsoft.Extensions.DependencyInjection;
using Salvation.Library.Common;
using Salvation.Library.Infrastructure.Abstractions;
using Salvation.Library.Infrastructure.Implementations;
using Salvation.Library.Services.Categories.Abstractions;
using Salvation.Library.Services.Categories.Implementations;

namespace Salvation.Services.Categories;

/// <summary>
/// ServiceProviderRegister
/// </summary>
public static class CategoryServiceRegister
{
    /// <summary>
    /// RegisterCategoryService
    /// </summary>
    /// <param name="services"></param>
    public static void RegisterCategoryService(this IServiceCollection services)
    {
        services.AddTransient<ICategoryService, CategoryService>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        services.RegisterProviders();
    }
}
