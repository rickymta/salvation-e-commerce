using Salvation.Library.Models.Entities;

namespace Salvation.Library.Infrastructure.Abstractions;

/// <summary>
/// ICategoryRepository
/// </summary>
public interface ICategoryRepository : IGenericRepository<Category>
{
    /// <summary>
    /// GetActiveCategories
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Category>?> GetActiveParentCategories();

    /// <summary>
    /// GetActiveChildrenCategoriesByParentId
    /// </summary>
    /// <param name="parentId"></param>
    /// <returns></returns>
    Task<IEnumerable<Category>?> GetActiveChildrenCategoriesByParentId(string parentId);
}
