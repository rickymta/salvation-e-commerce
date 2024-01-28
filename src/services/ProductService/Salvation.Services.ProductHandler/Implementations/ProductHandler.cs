using Salvation.Library.Common.Abstractions;
using Salvation.Library.Models.Entities;
using Salvation.Library.Services.Products.Abstractions;
using Salvation.Handlers.Products.Abstractions;
using Salvation.Library.Models.ViewModels;
using Salvation.Library.Services.Categories.Abstractions;
using Salvation.Library.Services.Manufactures.Abstractions;

namespace Salvation.Handlers.Products.Implementations;

/// <inheritdoc/>
internal class ProductHandler : IProductHandler
{
    /// <summary>
    /// IProductService
    /// </summary>
    private readonly IProductService _ProductService;

    /// <summary>
    /// ILogProvider
    /// </summary>
    private readonly ILogProvider _logProvider;

    /// <summary>
    /// ICategoryService
    /// </summary>
    private readonly ICategoryService _categoryService;

    /// <summary>
    /// IManufactureService
    /// </summary>
    private readonly IManufactureService _manufactureService;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="ProductService"></param>
    /// <param name="logProvider"></param>
    public ProductHandler(IProductService ProductService, ILogProvider logProvider, ICategoryService categoryService, IManufactureService manufactureService)
    {
        _ProductService = ProductService;
        _logProvider = logProvider;
        _categoryService = categoryService;
        _manufactureService = manufactureService;
    }

    /// <inheritdoc/>
    public async Task<int> CreateAsync(Product entity)
    {
        try
        {
            return await _ProductService.CreateAsync(entity);
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return 0;
        }
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(string id)
    {
        try
        {
            return await _ProductService.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return false;
        }
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<CategoryViewModel>?> GetActiveCategories()
    {
        var result = await _categoryService.GetActiveCategories();
        return result;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Product>?> GetAllAsync()
    {
        try
        {
            return await _ProductService.GetAllAsync();
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    /// <inheritdoc/>
    public async Task<Product?> GetAsync(string id)
    {
        try
        {
            return await _ProductService.GetAsync(id);
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return null;
        }
    }

    /// <inheritdoc/>
    public async Task<bool> UpdateAsync(Product entity)
    {
        try
        {
            return await _ProductService.UpdateAsync(entity);
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return false;
        }
    }
}
