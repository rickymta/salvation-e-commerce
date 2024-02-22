using Salvation.Library.Models.Common;
using Salvation.Library.Models.Entities;
using Salvation.Library.Models.Filter;
using Salvation.Library.Models.ViewModels;

namespace Salvation.Handlers.Products.Abstractions;

/// <summary>
/// IProductHandler
/// </summary>
public interface IProductHandler
{
    /// <summary>
    /// CreateAsync
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<int> CreateAsync(Product entity);

    /// <summary>
    /// GetAsync
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Product?> GetAsync(string id);

    /// <summary>
    /// GetAllAsync
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Product>?> GetAllAsync();

    /// <summary>
    /// UpdateAsync
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(Product entity);

    /// <summary>
    /// DeleteAsync
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(string id);

    /// <summary>
    /// CreateAsync
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<string> CreateCategoryAsync(Category entity);

    /// <summary>
    /// GetAsync
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Category?> GetCategoryAsync(string id);

    /// <summary>
    /// GetAllAsync
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Category>?> GetAllCategoryAsync();

    /// <summary>
    /// GetActiveCategories
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<CategoryViewModel>?> GetActiveCategories();

    /// <summary>
    /// FilterDataPaging
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    Task<DataPaging<Category>?> FilterCategoryDataPaging(CategoryFilter filter);

    /// <summary>
    /// UpdateAsync
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<bool> UpdateCategoryAsync(Category entity);

    /// <summary>
    /// DeleteAsync
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteCategoryAsync(string id);
}
