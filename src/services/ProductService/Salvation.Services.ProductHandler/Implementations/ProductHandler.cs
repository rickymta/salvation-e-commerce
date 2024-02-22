using Salvation.Library.Common.Abstractions;
using Salvation.Library.Models.Entities;
using Salvation.Library.Services.Products.Abstractions;
using Salvation.Handlers.Products.Abstractions;
using Salvation.Library.Models.ViewModels;
using Salvation.Library.Services.Categories.Abstractions;
using Salvation.Library.Services.Manufactures.Abstractions;
using Salvation.Library.Models.Common;
using Salvation.Library.Models.Filter;

namespace Salvation.Handlers.Products.Implementations;

/// <inheritdoc/>
internal class ProductHandler : IProductHandler
{
    /// <summary>
    /// IProductService
    /// </summary>
    private readonly IProductService _productService;

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
        _productService = ProductService;
        _logProvider = logProvider;
        _categoryService = categoryService;
        _manufactureService = manufactureService;
    }

    /// <inheritdoc/>
    public async Task<int> CreateAsync(Product entity)
    {
        try
        {
            return await _productService.CreateAsync(entity);
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
            return await _productService.DeleteAsync(id);
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
            return await _productService.GetAllAsync();
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
            return await _productService.GetAsync(id);
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
            return await _productService.UpdateAsync(entity);
        }
        catch (Exception ex)
        {
            _logProvider.Error(ex);
            return false;
        }
    }

    /// <inheritdoc/>
    public async Task<DataPaging<Category>?> FilterCategoryDataPaging(CategoryFilter filter)
    {
        var result = await _categoryService.FilterDataPaging(filter);
        return result;
    }

    /// <inheritdoc/>
    public async Task<string> CreateCategoryAsync(Category entity)
    {
        var result = await _categoryService.CreateAsync(entity);
        return result;
    }

    /// <inheritdoc/>
    public async Task<Category?> GetCategoryAsync(string id)
    {
        var result = await _categoryService.GetAsync(id);
        return result;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Category>?> GetAllCategoryAsync()
    {
        var result = await _categoryService.GetAllAsync();
        return result;
    }

    /// <inheritdoc/>
    public async Task<bool> UpdateCategoryAsync(Category entity)
    {
        var result = await _categoryService.UpdateAsync(entity);
        return result;
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteCategoryAsync(string id)
    {
        var result = await _categoryService.DeleteAsync(id);
        return result;
    }
}
