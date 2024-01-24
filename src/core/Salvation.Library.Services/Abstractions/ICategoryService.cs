using Salvation.Library.Models.Entities;

namespace Salvation.Library.Services.Abstractions
{
    /// <summary>
    /// ICategoryService
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// CreateAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> CreateAsync(Category entity);

        /// <summary>
        /// GetAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Category?> GetAsync(string id);

        /// <summary>
        /// GetAllAsync
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Category>?> GetAllAsync();

        /// <summary>
        /// UpdateAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(Category entity);

        /// <summary>
        /// DeleteAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(string id);
    }
}
